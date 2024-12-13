using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class UsuarioRolModel
    {
        [Key]
        public int id_usuario_rol { get; set; }
        public  int id_usuario { get; set; }
        public int id_rol { get; set; }

        public UsuarioModel Usuario { get; set; }
        public RolModel Rol { get; set; }

    }
}
