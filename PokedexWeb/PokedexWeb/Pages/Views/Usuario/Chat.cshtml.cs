using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class ChatViewModel : PageModel
    {
        private readonly MensajeService _mensajeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ChatService _chatService;

        public ChatViewModel(MensajeService mensajeService, IHttpContextAccessor httpContextAccessor, ChatService chatService)
        {
            _httpContextAccessor = httpContextAccessor;
            _mensajeService = mensajeService;
            _chatService = chatService;
        }

        public IEnumerable<MensajeModel> Mensajes { get; set; }
        [BindProperty]
        public int IdChat { get; set; }
        public ChatModel Chat { get; set; }
        [BindProperty]
        public string Mensaje { get; set; }


        public void OnGet([FromQuery(Name = "id")] string id)
        {
            IdChat = int.Parse(id);
            Mensajes = _mensajeService.GetMensajesChat(IdChat);
            Chat = _chatService.GetChat(IdChat);
        }

        public IActionResult OnPost()
        {
            int id_usuario = int.Parse(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            bool enviado = _mensajeService.addMensaje(IdChat, id_usuario, Mensaje);

            return RedirectToPage(new { id = IdChat });
        }
    }
}
