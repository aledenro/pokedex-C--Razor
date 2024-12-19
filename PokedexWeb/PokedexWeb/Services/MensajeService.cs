using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class MensajeService
    {
        private readonly ConnectionDbContext _dbContext;

        public MensajeService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MensajeModel> GetMensajesChat(int id_chat)
        {
            return _dbContext.Mensaje_G7.Include(m => m.Chat).ThenInclude(c => c.MensajesChat).Where(m => m.id_chat == id_chat).ToList();
        }

        public bool addMensaje(int id_chat, int id_envia, string mensaje)
        {
            try
            {
                MensajeModel model = new MensajeModel();
                model.id_chat = id_chat;
                model.mensaje = mensaje;
                model.id_envia = id_envia;

                _dbContext.Mensaje_G7.Add(model);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
