using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure / Core services to the container via ext method.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the container
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// API explorer services
builder.Services.AddEndpointsApiExplorer();

// Add swagger genderation services to create swagger
builder.Services.AddSwaggerGen();

// add cores services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// build the web application
var app = builder.Build();

// Add ExceptionHandlingMiddleware to the pipeline
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();
app.UseSwagger();

// add swagger UI interactive page
app.UseSwaggerUI();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
