using BrasileiraoApi.Infrastructure;
using BrasileiraoApi.Repositories;
using BrasileiraoApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = Environment.GetEnvironmentVariable("CONN_STRING");

builder.Services.AddDbContext<BrasileiraoDbContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("connectionString"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("connectionString"))));

builder.Services.AddScoped<IJogadorRepository, JogadorRepository>();
builder.Services.AddScoped<IJogadorService, JogadorService>();
builder.Services.AddScoped<ITituloRepository, TituloRepository>();
builder.Services.AddScoped<ITituloService, TituloService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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