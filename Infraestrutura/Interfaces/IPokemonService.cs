using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PokeAPI.Aplication.Interfaces
{
    public interface IPokemonService
    {
        Task<IActionResult> PegarSalvarPokemonsAsy();


    }
}