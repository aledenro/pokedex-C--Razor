using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class PokemonTipoService
    {
        private readonly ConnectionDbContext _dbContext;

        public PokemonTipoService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PokemonTipoModel> GetPokemonTipo()
        {
            return _dbContext.Pokemon_Tipo_G7.ToList();
        }

        public bool AddPokemonTipo(PokemonTipoModel pokemonTipo)
        {
            try
            {
                _dbContext.Pokemon_Tipo_G7.Add(pokemonTipo);
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
