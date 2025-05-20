using Microsoft.OpenApi.Models;
using PokeAPI.Models.DB;
using PokeAPI.Infraestrutura;
using PokeAPI.Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Aplication.UseCase;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ REGISTRA O SWAGGER
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddHttpClient<PokemonHttpClient>();
builder.Services.AddScoped<PokeAPI.Aplication.Repository.PokemonRepository>();
builder.Services.AddScoped<PokemonUseCase>();



builder.Services.AddScoped<PokemonUseCase>();


// banco de dados
builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

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