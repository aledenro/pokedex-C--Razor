using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class EquipoModel : PageModel
    {
        private readonly UsuarioPokemonService _usuarioPokemonService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly EnfermeriaService _enfermeriaService;

        public EquipoModel(UsuarioPokemonService usuarioPokemonService, IHttpContextAccessor httpContextAccessor, EnfermeriaService enfermeriaService)
        {
            _usuarioPokemonService = usuarioPokemonService;
            _httpContextAccessor = httpContextAccessor;
            _enfermeriaService = enfermeriaService;
        }

        public string Message { get; set; }

        public IEnumerable<UsuarioPokemonModel>  usuarioPokemons { get; set; }

        public void OnGet()
        {
            string id_usuario = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            usuarioPokemons = _usuarioPokemonService.GetUsuarioPokemonById(Int32.Parse(id_usuario));
        }

        public IActionResult OnPostEnfermeria(int id_pokemon, int id_usuario_pokemon)
        {
            string id_usuario = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            bool enfermeria = _enfermeriaService.AgregarPaciente(id_pokemon, Int32.Parse(id_usuario));

            if (!enfermeria) {
                Message = "Error al mandar el pokemon a la enfermeria.";
                return RedirectToPage();
            }

            _usuarioPokemonService.cambiarEstadoEnfermeria(Int32.Parse(id_usuario), id_pokemon, true);
            return RedirectToPage();
        }

        public IActionResult OnPostQuitar(int id_usuario_pokemon)
        {
            bool quitado = _usuarioPokemonService.Quitar(id_usuario_pokemon);

            if (!quitado)
            {
                Message = "Error al quitar el  pokemon de su equipo.";
            }

            return RedirectToPage();
        }
    }
}
