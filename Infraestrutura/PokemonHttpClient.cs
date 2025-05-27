using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PokeAPI.Infraestrutura
{
    public class PokemonHttpClient
    {
        
        private readonly HttpClient _httpClient;

        public PokemonHttpClient (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetPokemonListAsync(int limit = 5)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit={limit}");

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException();
            }

        }


        public async Task<string> GetPokemonSpeciesAsync(string pokemonName)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{pokemonName}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}