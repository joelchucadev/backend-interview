using Code.Handlers;
using Code.Handlers.Factory;
using Code.Repository;
using Code.Repository.SqlLite;
using Code.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7091",
                                              "https://localhost");
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection Pattern
builder.Services.AddSqlite<MyContext>(builder.Configuration["ConnectionStrings:Default"]);
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddSingleton<IPatternSolver, PatternSolver>();
builder.Services.AddSingleton<IResultFactory, ResultFactory>();
builder.Services.RegisterRequestHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
