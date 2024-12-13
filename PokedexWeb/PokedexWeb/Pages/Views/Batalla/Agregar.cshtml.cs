using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg.OpenPgp;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Batalla
{
    public class AgregarModel : PageModel
    {
        private readonly RetoService _retoService;
        private readonly UsuarioService _usuarioService;

        public AgregarModel(RetoService retoService, UsuarioService usuarioService)
        {
            _retoService = retoService;
            _usuarioService = usuarioService;
        }

        [BindProperty]
        public RetoModel Reto { get; set; }
        public IEnumerable<UsuarioModel> Usuarios { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            Usuarios = _usuarioService.GetUsersBasicInfo();
        }

        public IActionResult OnPost()
        {
            Reto.Estado = "Pendiente";

            bool agregado = _retoService.AddReto(Reto);

            if (!agregado)
            {
                Message = "Error al agregar el reto. Intente de nuevo.";
                return Page();
            }

            return RedirectToPage("/Views/Batalla/Batalla");
        }
    }
}
