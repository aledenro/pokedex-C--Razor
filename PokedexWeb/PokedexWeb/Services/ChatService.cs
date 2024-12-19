using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class ChatService
    {
        private readonly ConnectionDbContext _dbContext;

        public ChatService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ChatModel> GetChats(int id)
        {
            return _dbContext.Chat_G7.Where(c => c.id_usuario1 == id || c.id_usuario2 == id).Include(c => c.Usuario1).Include(c => c.Usuario2).ToList();
        }

        public bool AddChat(int id_usuario1, int usuario2)
        {
            try
            {
                ChatModel model = new ChatModel();
                model.id_usuario1 = id_usuario1;
                model.id_usuario2 = usuario2;

                _dbContext.Chat_G7.Add(model);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public ChatModel GetChat(int id) {
            return _dbContext.Chat_G7.Where(c => c.id_chat == id).Include(c => c.Usuario1).Include(c => c.Usuario2).Single();
        }
    }
}
