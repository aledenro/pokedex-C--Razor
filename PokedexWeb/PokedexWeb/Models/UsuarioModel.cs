using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class UsuarioModel
    {
        [Key]
        public int id_usuario { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }

        public bool estado {  get; set; }

        public ICollection<UsuarioRolModel> UsuarioRoles { get; set; }

        public ICollection<RetoModel> RetoRetador { get; set; }
        public ICollection<RetoModel> RetoContendiente { get; set; }

        public ICollection<EnfermeriaModel> EnfermeriaEntrenador { get; set; }
        public ICollection<EnfermeriaModel> EnfermeriaEnfermero { get; set; }
        public ICollection<UsuarioPokemonModel> UsuarioPokemons { get; set; }
        public ICollection<ChatModel> EnviaChat { get; set; }
        public ICollection<ChatModel> RecibeChat { get; set; }
    }
}
