using PokedexWeb.Data;

namespace PokedexWeb.Services
{
    public class RolUsuarioService
    {

        private readonly ConnectionDbContext _dbContext;

        public RolUsuarioService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
