using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class PokemonModel
    {
        [Key]
        public int id_pokemon { get; set; }
        public string nombre { get; set; }
        public int altura { get; set; }
        public int peso { get; set; }
        public string foto { get; set; }
    }
}
