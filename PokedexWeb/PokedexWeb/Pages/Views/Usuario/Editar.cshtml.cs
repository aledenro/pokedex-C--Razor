using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class EditarModel : PageModel
    {
        private readonly UsuarioService _usuarioService;
        private readonly RolUsuarioService _usuarioRolService;

        public EditarModel(UsuarioService usuarioService, RolUsuarioService usuarioRolService)
        {
            _usuarioService = usuarioService;
            _usuarioRolService = usuarioRolService;
        }

        [BindProperty]
        public UsuarioModel Usuario { get; set; }

        [BindProperty]
        public RolModel Rol { get; set; }

        [BindProperty]
        public bool Enfermero { get; set; }

        [BindProperty]
        public bool Admin {  get; set; }



        public void OnGet([FromQuery(Name = "id")] string id)
        {
            Usuario = _usuarioService.GetUsuarioById(Int32.Parse(id));

            foreach (var rol in Usuario.UsuarioRoles)

            {
                if (rol.Rol.rol == "Admin")
                {
                    Admin = true;
                }

                if (rol.Rol.rol == "Enfermero")
                {
                    Enfermero = true;
                }
            };
        }

        public IActionResult OnPost()
        {
            
            try
            {
                _usuarioRolService.deleteUsuarioRol(Usuario.id_usuario);

                _usuarioRolService.insertUsuarioRol(Usuario.id_usuario, 1);

                if (Admin)
                {
                    _usuarioRolService.insertUsuarioRol(Usuario.id_usuario, 3);
                }

                if (Enfermero)
                {
                    _usuarioRolService.insertUsuarioRol(Usuario.id_usuario, 1);

                    
                }

                return RedirectToPage("/Views/Usuario/AdminUsers");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Page();
            }



        }

    }
}
