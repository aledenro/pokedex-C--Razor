using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class TipoModel
    {
        [Key]
        public int id_tipo { get; set; }
        public string nombre { get; set; }

        public ICollection<PokemonTipoModel> PokemonTipos { get; set; }
    }
}
