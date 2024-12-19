using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class AgregarContactoModel : PageModel
    {
        private readonly ChatService _chatService;
        private readonly UsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AgregarContactoModel(ChatService chatService, UsuarioService usuarioService, IHttpContextAccessor httpContextAccessor)
        {
            _chatService = chatService;
            _usuarioService = usuarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<int> Chats { get; set; } = new List<int>();

        [BindProperty]
        public int id_usuario { get; set; }
        [BindProperty]
        public int id_contacto { get; set; }

        public string Message { get; set; }

        public IEnumerable<UsuarioModel> Usuarios{ get; set; }

        public void OnGet() { 
            id_usuario = int.Parse(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            Usuarios = _usuarioService.GetUsersBasicInfo();
            var chats = _chatService.GetChats(id_usuario);

            foreach (var ch in chats) {
                if (ch.id_usuario1 != id_usuario)
                {
                    Chats.Add(ch.id_usuario1);
                }
                else
                {
                    Chats.Add(ch.id_usuario2);
                }
            }
        }

        public IActionResult OnPost() {
            id_usuario = int.Parse(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            bool agregado = _chatService.AddChat(id_usuario, id_contacto);

            if (!agregado) {
                Message = "Error al agregar el contacto.";
                return RedirectToPage();
            }

            return RedirectToPage("/Views/Usuario/Contactos");
        }
    }
}
