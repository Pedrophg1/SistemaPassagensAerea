using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Repositories;
using Sistemapassagemaerea.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos repositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICompanhiaAereaRepository, CompanhiaAereaRepository>();
builder.Services.AddScoped<IPassageiroRepository, PassageiroRepository>();
builder.Services.AddScoped<IPassagemAereaRepository, PassagemAereaRepository>();

// Registro dos serviços
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICompanhiaAereaService, CompanhiaAereaService>();
builder.Services.AddScoped<IPassageiroService, PassageiroService>();
builder.Services.AddScoped<IPassagemAereaService, PassagemAereaService>();

builder.Services.AddControllers();

// Configuração do Swagger/OpenAPI
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
