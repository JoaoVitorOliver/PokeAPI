using PokeAPI.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokeAPI.Aplication.DTOs;
using PokeAPI.Infraestrutura;
using PokeAPI.Aplication.UseCase;
using PokeAPI.Aplication.Repository; // Se você tiver um repositório
using PokeAPI.Models.Entities;


public class PokemonService : IPokemonService
{
    private readonly PokemonHttpClient _pokemonHttpClient;
    private readonly SalvarCadastrarPokemonUseCase _pokemonUseCase;

    public PokemonService(PokemonHttpClient pokemonHttpClient, SalvarCadastrarPokemonUseCase pokemonUseCase)
    {
        _pokemonHttpClient = pokemonHttpClient;
        _pokemonUseCase = pokemonUseCase;
    }

    public async Task<IActionResult> PegarSalvarPokemonsAsy()
    {
        var pokemonListJson = await _pokemonHttpClient.GetPokemonListAsync();
        var jsonPokemon = JsonConvert.DeserializeObject<PokemonResponse>(pokemonListJson);

        var listaFinal = new List<Pokemonss>();
        foreach (var p in jsonPokemon!.listaPokemon!)
        {
            var pokemonSpeciesJson = await _pokemonHttpClient.GetPokemonSpeciesAsync(p.Name!);
            var jsonColor = JsonConvert.DeserializeObject<PokemonCores>(pokemonSpeciesJson);

            var cor = jsonColor?.ColorList!.Name ?? "Sem Cor Definida";
            listaFinal.Add(new Pokemonss { Nome = p.Name!, Cor = cor });
        }

        // Conversão de DTO para Entities e salvando no banco
        await _pokemonUseCase.SalvarListaAsync(listaFinal);


        var agruparPorCor = listaFinal
            .GroupBy(p => p.Cor)
            .ToDictionary(g => g.Key, g => g.Select(p => p.Nome).ToList());

        return new JsonResult(agruparPorCor);
    }
}