using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Enfermeria
{
    public class IndexModel : PageModel
    {
        private readonly EnfermeriaService _enfermeriaService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UsuarioPokemonService _usuarioPokemonService;

        public IndexModel(EnfermeriaService enfermeriaService, IHttpContextAccessor httpContextAccessor, UsuarioPokemonService usuarioPokemonService)
        {
            _enfermeriaService = enfermeriaService;
            _httpContextAccessor = httpContextAccessor;
            _usuarioPokemonService = usuarioPokemonService;
        }

        public IEnumerable<EnfermeriaModel> Pacientes { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            Pacientes = _enfermeriaService.GetEnfermeria();

        }

        public IActionResult OnPostAsignar(int id_detalle_enfermeria)
        {
            var id_enfermero = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            bool asignado = _enfermeriaService.Asignar(id_detalle_enfermeria, Int32.Parse(id_enfermero));

            if (!asignado)
            {
                Message = "Error al asignar el pokemon a sus pacientes.";
            }

            return RedirectToPage();
        }

        public IActionResult OnPostLiberar(int id_detalle_enfermeria,  int id_pokemon, int id_entrenador)
        {
            bool liberado = _enfermeriaService.Liberar(id_detalle_enfermeria);

            if (!liberado)
            {
                Message = "Error al dar de alta el pokemon.";
            }

            _usuarioPokemonService.cambiarEstadoEnfermeria(id_entrenador, id_pokemon, false);

            return RedirectToPage();
        }
    }
}
