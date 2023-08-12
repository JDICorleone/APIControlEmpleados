using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ControlEmpleadosContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("ControlEmpleadosContext")));

builder.Services.AddScoped<IEmpleadosModel, EmpleadosModel>();

builder.Services.AddScoped<IUsuariosModel, UsuariosModel>();

builder.Services.AddScoped<IPlanillasModel, PlanillasModel>();

builder.Services.AddScoped<IPuestosModel, PuestosModel>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
