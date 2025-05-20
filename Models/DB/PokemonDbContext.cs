using Microsoft.EntityFrameworkCore;
using PokeAPI.Models.Entities;


namespace PokeAPI.Models.DB
{
public class PokemonDbContext : DbContext
{
    public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pokemon> Pokemons { get; set; }
}
}