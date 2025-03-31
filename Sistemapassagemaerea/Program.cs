using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Application.Services;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Data.Mongodb;

using Sistemapassagemaerea.Data.Repositories;
using Sistemapassagemaerea.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();


builder.Services.AddScoped<ICompanhiaAereaRepository, CompanhiaAereaRepository>();
builder.Services.AddScoped<IPassageiroRepository, PassageiroRepository>();
builder.Services.AddScoped<IPassagemAereaRepository, PassagemAereaRepository>();
builder.Services.AddScoped<ICompanhiaAereaService, CompanhiaAereaService>();
builder.Services.AddScoped<IPassageiroService, PassageiroService>();
builder.Services.AddScoped<IPassagemAereaService, PassagemAereaService>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Registra o MongoClient e o MongoDatabase como serviços
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);  // Cria o cliente MongoDB com a string de conexão
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return client.GetDatabase(settings.DatabaseName); // Obtém o banco de dados MongoDB usando o nome configurado
});
builder.Services.AddScoped<IPassagemMongoRepository, PassagemMongoRepository>();





builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
