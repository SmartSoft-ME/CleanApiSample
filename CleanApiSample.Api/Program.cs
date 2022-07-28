using System.Text.Json.Serialization;

using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Infrastructure;
using CleanApiSample.Infrastructure.Data;

using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(PostDto));

builder.Services.AddInfrastructure();

builder.Services.AddControllers()
    .AddJsonOptions( o => 
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseHttpsRedirection();

app.UseInfrastructure();

app.UseAuthorization();

app.MapControllers();

app.Run();
