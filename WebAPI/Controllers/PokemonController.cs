using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Aplication.Interfaces;

namespace PokeAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        // O controller agora depende da interface IPokemonService
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("pegar-todos-pokemon")]
        public async Task<IActionResult> GetAllPokemonController()
        {
            // Chama o serviço para obter os Pokémons
            var resultado = await _pokemonService.GetAllPokemons();

            // Verifica se o resultado é nulo ou vazio
            if (resultado == null)
            {
                return NotFound("Nenhum Pokémon encontrado.");
            }

            // Retorna o resultado com status 200 (OK)
            return Ok(resultado);
        }
    }
}