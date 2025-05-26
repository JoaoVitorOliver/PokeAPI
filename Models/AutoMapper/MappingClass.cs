using PokeAPI.Aplication.DTOs;
using PokeAPI.Models.Entities;
using AutoMapper;

namespace PokeAPI.Models.AutoMapper
{
    public class MappingPokemon : Profile
    {
        public MappingPokemon()
        {
            CreateMap<Pokemonss, Pokemon>();
        }
    }
}