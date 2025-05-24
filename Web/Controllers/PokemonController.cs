using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Aplication.Interfaces;
using PokeAPI.Aplication.UseCase;
using PokeAPI.Aplication.DTOs;

namespace PokeAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly PokemonUseCase _pokemonUseCase;

        // O controller agora depende da interface IPokemonService
        public PokemonController(IPokemonService pokemonService, PokemonUseCase pokemonUseCase)
        {
            _pokemonUseCase = pokemonUseCase;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Show), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllPokemonController()
        {
            // Chama o serviço para obter os Pokémons
            var resultado = await _pokemonService.PegarSalvarPokemonsAsy();

            // Verifica se o resultado é nulo ou vazio
            if (resultado == null)
            {
                return NotFound("Nenhum Pokémon encontrado.");
            }

            // Retorna o resultado com status 200 (OK)
            return Ok(resultado);
        }

        

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Show), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PegarPokemonPorIdAsync([FromRoute] int id)
        {
            // Chama o serviço para obter o Pokémon por ID
            var resultado = await _pokemonUseCase.ObterPokemonDoRepositoryById(id);

            // Verifica se o resultado é nulo
            if (resultado == null)
            {
                return NotFound($"Pokémon com ID {id} não encontrado.");
            }

            // Retorna o resultado com status 200 (OK)
            return Ok(resultado);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarPokemonPorIdAsync(int id)
        {
            // Chama o serviço para deletar o Pokémon por ID
            await _pokemonUseCase.DeletarPokemonDoRepositoryById(id);

            // Retorna um status 204 (No Content) se a exclusão for bem-sucedida
            return NoContent();
        }
    }
}