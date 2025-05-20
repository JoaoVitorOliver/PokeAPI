using PokeAPI.Aplication.Repository;
using PokeAPI.Aplication.DTOs;
using PokeAPI.Models.Entities;

namespace PokeAPI.Aplication.UseCase
{
    public class PokemonUseCase
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonUseCase(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task SalvarListaAsync(List<Pokemonss> listaDto)
        {
            foreach (var pokeDto in listaDto)
            {
                var pokemonEntity = new Pokemon
                {
                    Nome = pokeDto.Nome,
                    Cor = pokeDto.Cor
                };
                await _pokemonRepository.AdicionarPokemonsNoBanco(pokemonEntity);
            }
        }
    }
}