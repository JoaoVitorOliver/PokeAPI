using PokeAPI.Aplication.Repository;

namespace PokeAPI.Aplication.UseCase
{
    public class DeletarPokemonDoRepositoryByIdUseCase
    {

        private readonly PokemonRepository _pokemonRepository;


        public DeletarPokemonDoRepositoryByIdUseCase(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }


        
        public async Task DeletarPokemonDoRepositoryById(int id)
        {
            var pokemon = await _pokemonRepository.ObterPokemonPorId(id);
            if (pokemon == null)
            {
                throw new Exception($"Pokémon com ID {id} não encontrado.");
            }
            await _pokemonRepository.DeletarPokemonPorId(id);
        }
    }
}