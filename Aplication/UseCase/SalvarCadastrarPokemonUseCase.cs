using PokeAPI.Aplication.Repository;
using PokeAPI.Aplication.DTOs;
using PokeAPI.Models.Entities;
using AutoMapper;

namespace PokeAPI.Aplication.UseCase
{
    public class SalvarCadastrarPokemonUseCase
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public SalvarCadastrarPokemonUseCase(PokemonRepository pokemonRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pokemonRepository = pokemonRepository;
        }

        public async Task SalvarListaAsync(List<Pokemonss> listaDto)
        {
            foreach (var pokeDto in listaDto)
            {
                var pokemonEntity = _mapper.Map<Pokemon>(pokeDto);
                await _pokemonRepository.AdicionarPokemonsNoBanco(pokemonEntity);
            }
        }
    }
}