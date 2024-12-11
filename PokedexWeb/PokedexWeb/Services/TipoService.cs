using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class TipoService
    {
        private readonly ConnectionDbContext _dbContext;

        public TipoService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TipoModel> GetTipos()
        {
            return _dbContext.Tipo_G7.ToList();
        }

        public bool AddTipo(TipoModel tipo)
        {
            try
            {
                _dbContext.Tipo_G7.Add(tipo);
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
