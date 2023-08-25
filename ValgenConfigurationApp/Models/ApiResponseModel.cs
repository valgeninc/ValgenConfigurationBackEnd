using System.Net;

namespace ValgenConfigurationApp.Models
{
    public class ApiResponseModel
    {
        public string Status { get; set; }
        public object? Result { get; set; }
        public Error Error { get; set; }
        public ApiResponseModel() { }
        public ApiResponseModel(HttpStatusCode statusCode, object result = null, Error error = null)
        {
            Status = statusCode.ToString();
            Result = result;
            if (error != null)
            {
                error.ErrorCode = error?.ErrorCode.ToString();
                error.ErrorMessage = error?.ErrorMessage.ToString();
            }
        }
    }

    public class Error
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        //public Error(string errorMessage, string errorCode)
        //{
        //    ErrorCode = errorCode.ToString();
        //    ErrorMessage = errorMessage.ToString();
        //}
    }
}
