using Microsoft.EntityFrameworkCore;
using RagProject.API.Contracts;
using RagProject.API.Extensions;
using RagProject.API.Features;
using RagProject.API.Middlewares;
using RagProject.Application.Documents;
using RagProject.Infrastructure.Documents;
using RagProject.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddTransient<IModule, DocumentModule>();

builder.Services.AddTransient<CustomExceptionHandlerMiddleware>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

//app.UseMiddleware<RequestTimingMiddleware>();

app.RegisterEndpoints();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
