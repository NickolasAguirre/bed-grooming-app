using bed_grooming_app.application.UseCases.Service;
using bed_grooming_app.Configuration.DIExtension;
using bed_grooming_app.domain.Repositories;
using bed_grooming_app.infrastructure.Repositories;
using bed_grooming_app.repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BedGroomingContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar Repositorios
builder.Services.AddDIExtension(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bed Grooming App API V1");
        options.RoutePrefix = ""; // ? CLAVE: Mostrar Swagger en la raíz
    });
    app.MapOpenApi();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
