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
    }
}
