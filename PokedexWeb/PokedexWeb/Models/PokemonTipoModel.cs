using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class PokemonTipoModel
    {
        [Key]
        public int id_pokemon_tipo { get; set; }
        public int id_pokemon { get; set; }
        public int id_tipo{ get; set; }

        public PokemonModel Pokemon { get; set; }
        public TipoModel Tipo { get; set; }
    }
}
