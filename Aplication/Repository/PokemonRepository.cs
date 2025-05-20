using PokeAPI.Models.DB;
using PokeAPI.Models.Entities;


namespace PokeAPI.Aplication.Repository
{
    public class PokemonRepository
    {
        private readonly PokemonDbContext _dbContext;

        public PokemonRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarPokemonsNoBanco(Pokemon pokemon)
        {
            _dbContext.Pokemons.Add(pokemon);
            await _dbContext.SaveChangesAsync();
        }
    }
}