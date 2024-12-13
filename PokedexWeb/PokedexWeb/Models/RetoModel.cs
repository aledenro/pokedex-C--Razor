namespace PokedexWeb.Models
{
    public class RetoModel
    {
        public  int id_reto {get; set;}
        public int id_retador { get; set; }
        public int id_contendiente { get; set; }
        public string Estado { get; set; }
        public string ganador { get; set; }
        public string lugar { get; set; }
        public DateOnly fecha {  get; set; } 

        public UsuarioModel Retador { get; set; }
        public UsuarioModel Contendiente { get; set; }
    }
}
