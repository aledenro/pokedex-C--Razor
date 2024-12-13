using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class PokemonService
    {
        private readonly ConnectionDbContext _dbContext;

        public PokemonService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PokemonModel> GetPokemones()
        {
             return _dbContext.Pokemon_G7.Include(p => p.PokemonTipos).ThenInclude(pt => pt.Tipo).Include(p => p.PokemonHabilidades).ThenInclude(ph => ph.Habilidad).ToList();
        }

        public bool AddPokemon(PokemonModel pokemon)
        {
            try
            {
                _dbContext.Pokemon_G7.Add(pokemon);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public int GetMaxPokemonId()
        {
            return _dbContext.Pokemon_G7.Max(p => p.id_pokemon);
        }

        public PokemonModel GetPokemon(int id) {
            return _dbContext.Pokemon_G7.Where(x => x.id_pokemon == id).Include(p => p.PokemonTipos).ThenInclude(pt => pt.Tipo).Include(p => p.PokemonHabilidades).ThenInclude(ph => ph.Habilidad).Single();
        }

        public void EditPokemon(PokemonModel pokemon) {

            var existingPokemon = _dbContext.Pokemon_G7.Find(pokemon.id_pokemon);

            if (existingPokemon != null)
            {
                existingPokemon.nombre = pokemon.nombre;
                existingPokemon.altura = pokemon.altura;
                existingPokemon.peso = pokemon.peso;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("El Pokémon no existe en la base de datos.");
            }
        }
    }
}
