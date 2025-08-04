using BibliotecaAPI.Database;
using BibliotecaAPI.Filters;
using BibliotecaAPI.Repositories;
using BibliotecaAPI.Repositories.Interfaces;
using BibliotecaAPI.Services;
using BibliotecaAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

// Add log configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add Init Log
builder.Host.UseSerilog();

// Add services for controllers (API)
// API filters and logging
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogAccessFilter>();
    options.Filters.Add<ExceptionHandlerFilter>();
    options.Filters.Add<ResponseTimeFilter>();
    options.Filters.Add<NotFoundOnNullResultFilter>();
});

// Add FluentValidations
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>(); // Register all validators

// Add Dependency Injection to AutoMappers
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddAutoMapper(typeof(Program));

// Register DbContext using SQLite and get connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryAPI", Version = "v1" });
});

var app = builder.Build();

// Middleware that runs only in development environment to enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensures all requests are redirected to HTTPS (secure connection)
app.UseHttpsRedirection();

// Middleware that checks if the user is authorized to access resources
app.UseAuthorization();

// Maps routes to API controllers
app.MapControllers();

// Starts the application and begins listening for incoming requests
app.Run();