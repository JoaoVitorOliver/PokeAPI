using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPI.Models.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }
    }
}