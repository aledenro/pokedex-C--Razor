using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexWeb.Models
{
    public class EnfermeriaModel
    {
        public int id_detalle_enfermeria {get; set;}
        public int id_entrenador {get; set;}
        public int id_pokemon { get; set; }
        public int? id_enfermero { get; set; }
        public DateOnly fecha { get; set; }
        public string estado { get; set; }

        [ForeignKey("id_entrenador")]
        public UsuarioModel Entrenador { get; set; }

        [ForeignKey("id_enfermero")]
        public UsuarioModel Enfermero { get; set; }

        [ForeignKey("id_pokemon")]
        public PokemonModel Pokemon { get; set; }
    }
}
