using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views
{
    public class RegistroModel : PageModel
    {
        private  readonly UsuarioService  _usuarioService;

        public RegistroModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]
        public UsuarioModel  Usuario { get; set; }
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            if(_usuarioService.GetUsuarioByEmail(Usuario.username) != null)
            {
                Message = "Ya  existe un usuario con ese  correo";
                return Page();
            }

            Usuario.estado = true;

            bool creado  = _usuarioService.CreateUser(Usuario);

            return Page();

        }
    }
}
