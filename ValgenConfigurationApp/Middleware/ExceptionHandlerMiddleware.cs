using Azure.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using ValgenConfigurationApp.Common;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Repository.Models;

namespace ValgenConfigurationApp.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var body = await FormatRequest(context.Request);
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionMessageAsync(context, ex, body).ConfigureAwait(false);
            }
        }
        private static async Task HandleExceptionMessageAsync(HttpContext context, Exception exception, string body)
        {
            context.Response.ContentType = "application/json";
            context.Request.EnableBuffering();
            var result = JsonConvert.SerializeObject(new
            {
                Source = exception.Source,
                ErrorMessage = exception.Message,
                ExceptionType = exception.GetType().FullName,
                Path = context.Request.Path,
                Request = body
            });
            await ApiLogging.InsertLog(result, Enums.MessageType.Error.ToString(), new Guid(), context.RequestServices.GetRequiredService<DatabaseContext>());
            context.Response.ContentType = "application/json";
            var apiiResponse = new ApiResponseModel()
            {
                Status = HttpStatusCode.BadRequest.ToString(),
                Error = new Error()
                {
                    ErrorCode = HttpStatusCode.BadRequest.ToString(),
                    ErrorMessage = exception.Message,
                }
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(apiiResponse).ToString());

        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var body = request.Body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;
            return bodyAsText;
        }
    }
}
