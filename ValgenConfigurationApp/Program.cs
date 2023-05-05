using Microsoft.EntityFrameworkCore;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adding database connection.
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ValgenDB")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Adding LoginAuthentication service.
builder.Services.AddTransient<IUserService, UserService>();

// Adding User repository.
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
