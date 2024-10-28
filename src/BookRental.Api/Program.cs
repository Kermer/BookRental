using BookRental.Api.Contracts;
using BookRental.Api.Contracts.Requests;
using BookRental.Api.Data;
using BookRental.Api.Models;
using BookRental.Api.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Text.Json.Serialization;
using BookRental.Api.Contracts.Requests.Parameters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ORM
builder.Services.AddDbContext<BookContext>(options =>
{
    options.UseInMemoryDatabase("BookRental");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
// Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateOrUpdateBookRequest>, BookRequestValidator>();
builder.Services.AddScoped<IValidator<Book>, BookValidator>();
builder.Services.AddScoped<IIsbnValidator, IsbnValidator>();
builder.Services.AddScoped<IValidator<BookStatusChange>, BookStatusChangeValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();