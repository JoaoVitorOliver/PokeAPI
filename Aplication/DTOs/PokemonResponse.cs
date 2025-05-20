using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeAPI.Aplication.DTOs
{
    public class PokemonResponse
    {
        [JsonProperty("results")]
        public List<PokemonDetails>? listaPokemon { get; set; }
    }

    public class PokemonDetails
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }

    public class PokemonCores
    {
        [JsonProperty("color")]
        public Color? ColorList { get; set; }
    }

    public class Color
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }


    public class Pokemonss
    {
        public string Nome { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
    }
}