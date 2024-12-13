using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class AdminUsersModel : PageModel
    {
        private readonly UsuarioService _usuarioService;

        public AdminUsersModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IEnumerable<UsuarioModel> Usuarios { get; set; }

        public async Task OnGet()
        {
            Usuarios = _usuarioService.GetAllUsuarios();
        }

    }
}
