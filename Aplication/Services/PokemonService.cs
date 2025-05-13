using PokeAPI.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokeAPI.Aplication.DTOs;
using PokeAPI.Infraestrutura;

namespace PokeAPI.Infrastructure.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly PokemonHttpClient _pokemonHttpClient;

        public PokemonService(PokemonHttpClient pokemonHttpClient)
        {
            _pokemonHttpClient = pokemonHttpClient;
        }

        public async Task<IActionResult> GetAllPokemons()
        {
            var pokemonListJson = await _pokemonHttpClient.GetPokemonListAsync();
            var jsonPokemon = JsonConvert.DeserializeObject<PokemonResponse>(pokemonListJson);

            var listaFinal = new List<Pokemon>();
            foreach (var p in jsonPokemon!.listaPokemon!)
            {
                var pokemonSpeciesJson = await _pokemonHttpClient.GetPokemonSpeciesAsync(p.Name!);
                var jsonColor = JsonConvert.DeserializeObject<PokemonCores>(pokemonSpeciesJson);

                var cor = jsonColor?.ColorList!.Name ?? "Sem Cor Definida";
                listaFinal.Add(new Pokemon { Nome = p.Name!, Cor = cor });
            }

            var agruparPorCor = listaFinal
                .GroupBy(p => p.Cor)
                .ToDictionary(g => g.Key, g => g.Select(p => p.Nome).ToList());

            return new JsonResult(agruparPorCor);
        }
    }
}