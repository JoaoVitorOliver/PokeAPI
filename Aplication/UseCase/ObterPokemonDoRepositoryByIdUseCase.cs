using PokeAPI.Aplication.Repository;
using PokeAPI.Models.Entities;

namespace PokeAPI.Aplication.UseCase
{
    public class ObterPokemonDoRepositoryByIdUseCase
    {

        private readonly PokemonRepository _pokemonRepository;

        public ObterPokemonDoRepositoryByIdUseCase(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        
        public async Task<Pokemon> ObterPokemonDoRepositoryById(int id)
        {
            var pokemon = await _pokemonRepository.ObterPokemonPorId(id);
            if (pokemon == null)
            {
                throw new Exception($"Pokémon com ID {id} não encontrado.");
            }
            return pokemon;
        }
    }
}