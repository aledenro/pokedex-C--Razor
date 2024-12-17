using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class EditarPokemonModel : PageModel
    {

        private readonly UsuarioPokemonService _usuarioPokemonService;

        public EditarPokemonModel(UsuarioPokemonService usuarioPokemonService)
        {
            _usuarioPokemonService = usuarioPokemonService;
        }

        [BindProperty]
        public string Nombre { get; set; }
        [BindProperty]
        public int id_usuario_pokemon { get; set; }
        public string Message { get; set; }

        public void OnGet([FromQuery(Name = "id")] string id)
        {
            id_usuario_pokemon = int.Parse(id);
            var pokemon = _usuarioPokemonService.GetUsuarioPokemonByIdRecord(id_usuario_pokemon);

            Nombre = pokemon.nombre;
        }

        public IActionResult OnPost()
        {
            bool editado = _usuarioPokemonService.Edit(id_usuario_pokemon, Nombre);

            if (!editado) {
                Message = "Error al editar el nombre de su pokemon.";
                return RedirectToPage();
            }

            return RedirectToPage("/Views/Usuario/Equipo");
        }
    }
}
