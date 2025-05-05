using Application.Interfaces;
using Application.Services;
using FerramentaAPI.Domain.Interfaces;
using FerramentaAPI.Infra.Data;
using FerramentaAPI.Infra.Logs;
using FerramentaAPI.Presentation.Middleware;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
string webhooksUrl = builder.Configuration["DiscordWebhookUrl"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddSingleton<IFerramentaRepository, InMemoryFerramentaRepository>(); 
builder.Services.AddSingleton<IFerramentaService, FerramentaService>();
builder.Services.AddSingleton(new DiscordLogs(webhooksUrl));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
