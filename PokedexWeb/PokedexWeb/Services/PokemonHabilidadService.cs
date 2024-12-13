using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class PokemonHabilidadService
    {
        private readonly ConnectionDbContext _dbContext;

        public PokemonHabilidadService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PokemonHabilidadModel> GetPokemonHabilidad()
        {
            return _dbContext.Pokemon_Habilidad_G7.ToList();
        }

        public bool AddPokemonHabilidad(PokemonHabilidadModel pokemonHabilidad)
        {
            try
            {
                _dbContext.Pokemon_Habilidad_G7.Add(pokemonHabilidad);
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
