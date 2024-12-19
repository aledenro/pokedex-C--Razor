using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexWeb.Models
{
    public class ChatModel
    {
        public int id_chat{  get; set; }
        public int id_usuario1 { get; set; }
        public int id_usuario2 { get; set; }

        public UsuarioModel Usuario1 { get; set; }
        public UsuarioModel Usuario2 { get; set; }
    }
}
