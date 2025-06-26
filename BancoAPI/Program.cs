using BancoAPI.Data;
using BancoAPI.Services;
using BancoAPI.Middlewares;  
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BancoAPI",
        Version = "v1",
        Description = "API para operaciones bancarias"
    });
});

// Ruta absoluta para la base de datos SQLite
var dbPath = Path.Combine(AppContext.BaseDirectory, "banco.db");
Console.WriteLine($"Ruta base de la base de datos: {dbPath}");

builder.Services.AddDbContext<BancoDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<ITransaccionService, TransaccionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BancoAPI v1");
    });
}

// Middleware global para manejo de excepciones
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
