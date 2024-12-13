using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class RetoService
    {
        private readonly ConnectionDbContext _dbContext;

        public RetoService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RetoModel> GetRetos()
        {
            return _dbContext.Reto_G7.Include(r => r.Retador).ThenInclude(u => u.RetoRetador).Include(r => r.Contendiente).ThenInclude(u => u.RetoContendiente);
        }

        public bool AddReto(RetoModel reto) {
            try
            {
                _dbContext.Reto_G7.Add(reto);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public RetoModel GetReto(int id)
        {
            return _dbContext.Reto_G7.Where(r => r.id_reto == id).Single();
        }

        public bool EditReto(RetoModel reto)
        {
            try
            {
                _dbContext.Entry(reto).State = EntityState.Modified;
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
