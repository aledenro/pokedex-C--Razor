using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class PokemonHabilidadModel
    {
        [Key]
        public int id_pokemon_habilidad { get; set; }
        public int id_pokemon { get; set; }
        public int id_habilidad { get; set; }

        public PokemonModel Pokemon { get; set; }
        public HabilidadModel Habilidad { get; set; }
    }
}
