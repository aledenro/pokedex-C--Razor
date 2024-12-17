using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class UsuarioPokemonService
    {
        private readonly ConnectionDbContext _dbContext;

        public UsuarioPokemonService(ConnectionDbContext connectionContext)
        {
            _dbContext = connectionContext;
        }

        public bool AddPokemonUsuario(int id_usuario, int id_pokemon, string nombre)
        {
            try
            {
                UsuarioPokemonModel model = new UsuarioPokemonModel();
                model.id_usuario = id_usuario;
                model.id_pokemon = id_pokemon;
                model.nombre = nombre;
                model.enfermeria = false;

                _dbContext.UsuarioPokemon_G7.Add(model);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<UsuarioPokemonModel> GetUsuarioPokemonById(int id_usuario)
        {
            return  _dbContext.UsuarioPokemon_G7.Include(up  => up.pokemon).Include(up => up.usuario).Where(up => up.id_usuario == id_usuario).ToList();
        }

        public bool existeEquipo(int id_usuario, int id_pokemon)
        {
            var pokemon = _dbContext.UsuarioPokemon_G7.Where(up => up.id_usuario == id_usuario && up.id_pokemon == id_pokemon);

            return pokemon.Any();
        }

        public void cambiarEstadoEnfermeria(int id_usuario, int id_pokemon,  bool estado)
        {
            var pokemon = _dbContext.UsuarioPokemon_G7.Where(up => up.id_usuario == id_usuario && up.id_pokemon == id_pokemon).Single();
            pokemon.enfermeria = estado;

            _dbContext.SaveChanges();
            
        }

        public bool Quitar(int id)
        {
            try
            {
                var pokemon = _dbContext.UsuarioPokemon_G7.Where(up => up.id_usuario_pokemon == id).Single();
                _dbContext.UsuarioPokemon_G7.Remove(pokemon);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Edit(int id, string nombre)
        {
            try
            {
                var pokemon = _dbContext.UsuarioPokemon_G7.Where(up => up.id_usuario_pokemon == id).Single();
                pokemon.nombre = nombre;
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public UsuarioPokemonModel GetUsuarioPokemonByIdRecord(int id)
        {
            return _dbContext.UsuarioPokemon_G7.Where(up => up.id_usuario_pokemon == id).Single();
        }
    }
}
