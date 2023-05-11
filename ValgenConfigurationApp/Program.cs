using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:loginKey"]))
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
builder.Services.AddTransient<ISubscriberRepository,  SubscriberRepository>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
