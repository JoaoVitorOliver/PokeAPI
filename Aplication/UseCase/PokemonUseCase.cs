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

        public async Task<Pokemon> ObterPokemonDoRepositoryById(int id)
        {
            var pokemon = await _pokemonRepository.ObterPokemonPorId(id);
            if (pokemon == null)
            {
                throw new Exception($"Pokémon com ID {id} não encontrado.");
            }
            return pokemon;

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