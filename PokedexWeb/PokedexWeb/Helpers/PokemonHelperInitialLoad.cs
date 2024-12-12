using Microsoft.AspNetCore.Authentication;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Helpers
{
    public class PokemonHelperInitialLoad
    {
        private readonly PokeApiService _pokeApiService;
        private readonly PokemonService _pokemonService;
        private readonly PokemonTipoService _pokemonTipoService;

        public PokemonHelperInitialLoad(PokeApiService pokeApiService, PokemonService pokemonService, PokemonTipoService pokemonTipoService)
        {
            _pokeApiService = pokeApiService;
            _pokemonService = pokemonService;
            _pokemonTipoService = pokemonTipoService;
        }


        public async Task InitialLoadPokemones()
        {
            IEnumerable<PokemonModel> pokemonesDb = Enumerable.Empty<PokemonModel>(); ;

            try
            {
                pokemonesDb = _pokemonService.GetPokemones();

                if (pokemonesDb != null && pokemonesDb.Count() <= 0)
                {
                    var data = await _pokeApiService.GetAllPokemonesFirstLoad();

                    if (data != null)
                    {
                        var pokemones = data.RootElement.GetProperty("results");

                        foreach (var pokemon in pokemones.EnumerateArray())
                        {

                            var isNullOrHasNoProperties = !pokemon.GetType().GetProperties().Any();

                            if (!isNullOrHasNoProperties)
                            {
                                string url = pokemon.GetProperty("url").GetString();

                                var detailPokemon = await _pokeApiService.GetPokemonFromUrl(url);

                                if (detailPokemon != null)
                                {
                                    int id = detailPokemon.RootElement.GetProperty("id").GetInt32();
                                    string nombre = detailPokemon.RootElement.GetProperty("name").GetString().ToUpper();
                                    int peso = detailPokemon.RootElement.GetProperty("weight").GetInt32();
                                    int altura = detailPokemon.RootElement.GetProperty("height").GetInt32();
                                    var fotos = detailPokemon.RootElement.GetProperty("sprites");
                                    string foto = "";

                                    if(fotos.GetProperty("front_default").GetString() != null)
                                    {
                                        foto = fotos.GetProperty("front_default").GetString();
                                    }

                                    PokemonModel pokemonModel = new PokemonModel();
                                    pokemonModel.id_pokemon = id;
                                    pokemonModel.nombre = nombre;
                                    pokemonModel.altura = altura;
                                    pokemonModel.foto = foto;
                                    pokemonModel.peso = peso;

                                    _pokemonService.AddPokemon(pokemonModel);

                                    var tipos = detailPokemon.RootElement.GetProperty("types").EnumerateArray();

                                    foreach (var tipo in tipos) {
                                        string tipoNombre = tipo.GetProperty("type").GetProperty("name").GetString();
                                        string urlType = tipo.GetProperty("type").GetProperty("url").GetString();


                                        string idType = urlType.Replace("https://pokeapi.co/api/v2/type/", "");
                                        idType = idType.Replace("/", "");

                                        PokemonTipoModel pokemonTipo = new PokemonTipoModel();
                                        pokemonTipo.id_pokemon = id;
                                        pokemonTipo.id_tipo = Int32.Parse(idType);

                                        _pokemonTipoService.AddPokemonTipo(pokemonTipo);
                                    }

                                    //_pokemonTipoService.AddPokemonTipo(Pokemon);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return;
            }
        }

        private void addTipoPokemon(int idPokemon, int idTipo)
        {
            
        }
    }
}
