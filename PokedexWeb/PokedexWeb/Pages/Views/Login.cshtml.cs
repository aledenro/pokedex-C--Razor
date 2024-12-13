using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views
{
    public class LoginModel : PageModel
    {

        private readonly UsuarioService _usuarioService;

        public LoginModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]
        public UsuarioModel Usuario { get; set; }

        public string Message { get; set; }


        public IActionResult OnPost()
        {
            var user = _usuarioService.GetUsuarioByEmail(Usuario.username);

            if (user == null)
            {
                Message = "No  existe un usuario con ese  correo";
                return Page();
            }

            if (user.password != Usuario.password) {
                Message = "La combinación de correo y contraseña no es correcta.";
                return Page();
            }

            HttpContext.Session.SetString("Username", user.username);
            HttpContext.Session.SetString("UserId", user.id_usuario  + "");

            return RedirectToPage("/Index");
        }
    }
}
