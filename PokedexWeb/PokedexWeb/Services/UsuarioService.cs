using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class UsuarioService
    {
        private readonly ConnectionDbContext _dbContext;

        public UsuarioService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UsuarioModel GetUsuarioByEmail(string correo)
        {
            return _dbContext.Usuario_G7
                .Include(u => u.UsuarioRoles) 
                .ThenInclude(ur => ur.Rol)   
                .SingleOrDefault(u => u.username == correo);
        }

        public bool CreateUser(UsuarioModel model)
        {
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
