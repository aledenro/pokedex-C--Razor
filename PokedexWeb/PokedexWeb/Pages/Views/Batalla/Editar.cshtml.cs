using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg.OpenPgp;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Batalla
{
    public class EditarModel : PageModel
    {
        private readonly RetoService _retoService;
        private readonly UsuarioService _usuarioService;

        public EditarModel(RetoService retoService, UsuarioService usuarioService)
        {
            _retoService = retoService;
            _usuarioService = usuarioService;
        }

        [BindProperty]
        public RetoModel Reto { get; set; }
        public IEnumerable<UsuarioModel> Usuarios { get; set; }
        public string Message { get; set; }

        public void OnGet([FromQuery(Name = "id")] string id)
        {
            Reto = _retoService.GetReto(Int32.Parse(id));
            Usuarios = _usuarioService.GetUsersBasicInfo();
        }

        public IActionResult OnPost()
        {

            bool editado = _retoService.EditReto(Reto);

            if (!editado)
            {
                Message = "Error al editar el reto. Intente de nuevo.";
                return Page();
            }

            return RedirectToPage("/Views/Batalla/Batalla");
        }
    }
}
