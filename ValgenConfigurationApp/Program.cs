using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ValgenConfigurationApp.Middleware;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Adding database connection.
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ValgenDB")));

// Adding JwtBearer Authorisation.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JwtAdmin:Issuer"],
            ValidAudience = builder.Configuration["JwtAdmin:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAdmin:Key"]))
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Adding User service.
builder.Services.AddTransient<IUserService, UserService>();

// Adding Subscriber service.
builder.Services.AddTransient<ISubscriberService, SubscriberService>();

// Adding User repository.
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Adding Subscriber Repository.
builder.Services.AddTransient<ISubscriberRepository, SubscriberRepository>();


builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    { jwtSecurityScheme, Array.Empty<string>() }
});
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("corsapp");

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();
app.MapControllers();

app.Run();