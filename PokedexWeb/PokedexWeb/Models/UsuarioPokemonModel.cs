namespace PokedexWeb.Models
{
    public class UsuarioPokemonModel
    {
        public int id_usuario_pokemon {  get; set; }
        public int id_usuario { get; set; }
        public int id_pokemon { get; set; }
        public string nombre { get; set; }
        public  bool enfermeria { get; set; }

        public PokemonModel pokemon { get; set; }
        public UsuarioModel usuario { get; set; }
    }
}
