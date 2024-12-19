using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class ContactosModel : PageModel
    {
        private readonly ChatService _chatService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactosModel(ChatService chatService, IHttpContextAccessor httpContextAccessor)
        {
            _chatService = chatService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<ChatModel> chats { get; set; }



        public void OnGet()
        {
            int id_usuario = int.Parse(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            chats = _chatService.GetChats(id_usuario);
        }
    }
}
