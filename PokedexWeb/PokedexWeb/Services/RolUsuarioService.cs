using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class RolUsuarioService
    {

        private readonly ConnectionDbContext _dbContext;

        public RolUsuarioService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool insertUsuarioRol(int idUsuario, int idRol)
        {
            try
            {
                UsuarioRolModel model = new UsuarioRolModel();
                model.id_usuario = idUsuario;
                model.id_rol = idRol;

                _dbContext.Usuario_Rol_G7.Add(model);
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
