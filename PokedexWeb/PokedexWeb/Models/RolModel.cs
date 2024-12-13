using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class RolModel
    {
        [Key]
        public int id_rol { get; set; }
        public string rol { get; set; }

        public ICollection<UsuarioRolModel> UsuarioRoles { get; set; }
    }
}
