using BooksApi.Infrastructure.Data;
using BooksApi.Repositories;
using BooksApi.Repositories.Interfaces;
using BooksApi.Services;
using BooksApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi(); // Map OpenAPI endpoint
app.MapScalarApiReference(options => options
    .WithTitle("Demo API")
    .WithTheme(ScalarTheme.Saturn)
    .WithDarkMode()
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));
    

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowOrigin");
app.MapControllers();
app.MapGet("/", () => Results.Content("Welcome to Books API! Visit /scalar for Scalar UI or /openapi for Swagger UI.", "text/plain"));

app.Run();