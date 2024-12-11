using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class HabilidadService
    {
        private readonly ConnectionDbContext _dbContext;

        public HabilidadService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<HabilidadModel> GetHabilidades()
        {
            return _dbContext.Habilidad_G7.ToList();
        }

        public bool AddHabilidad(HabilidadModel habilidad)
        {
            try
            {
                _dbContext.Habilidad_G7.Add(habilidad);
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
