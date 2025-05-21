using System.Data.Common;
using PokeAPI.Models.DB;
using PokeAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _dbContext.Pokemons.Add(pokemon);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new InvalidOperationException("Erro ao adicionar Pokémon no banco de dados.");
            }
        }

        public async Task<Pokemon?> ObterPokemonPorId(int id)
        {
            try
            {
                return await _dbContext.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (DbException)
            {
                throw new InvalidOperationException("Erro ao obter Pokémon por ID.");
            }
        }

        public async Task DeletarPokemonPorId(int id)
        {
            try
            {
                var pokemon = await ObterPokemonPorId(id);
                if (pokemon == null)
                {
                    throw new InvalidOperationException($"Pokémon com ID {id} não encontrado.");
                }
                _dbContext.Pokemons.Remove(pokemon);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new InvalidOperationException("Erro ao deletar Pokémon por ID.");
            }
        }
    }
}