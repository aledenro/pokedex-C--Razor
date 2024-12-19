using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class MensajeModel
    {
        [Key]
        public int id_mensaje { get; set; }
        public int id_chat { get; set; }
        public int id_envia { get; set; }
        public string mensaje { get; set; }

        public ChatModel Chat { get; set; }
    }
}
