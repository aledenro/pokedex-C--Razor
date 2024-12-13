using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class HabilidadModel
    {
        [Key]
        public int id_habilidad{ get; set; }
        public string nombre { get; set; }

        public ICollection<PokemonHabilidadModel> PokemonHabilidades { get; set; }
    }
}
