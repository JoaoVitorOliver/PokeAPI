using Microsoft.OpenApi.Models;
using PokeAPI.Infrastructure.Services;
using PokeAPI.Aplication.DTOs;
using PokeAPI.Infraestrutura;
using PokeAPI.Aplication.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ REGISTRA O SWAGGER
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddHttpClient<PokemonHttpClient>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // <- garante que seus endpoints funcionem

app.Run();