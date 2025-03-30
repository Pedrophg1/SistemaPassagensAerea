using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Application.Services;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Data.Mongodb;
using Sistemapassagemaerea.Data.Mongodb.Repositories;
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

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddScoped<ICompanhiaAereaMongoRepository, CompanhiaAereaMongoRepository>();
builder.Services.AddScoped<IPassageiroMongoRepository, PassageiroMongoRepository>();
builder.Services.AddScoped<IPassagemAereaMongoRepository, PassagemAereaMongoRepository>();



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
