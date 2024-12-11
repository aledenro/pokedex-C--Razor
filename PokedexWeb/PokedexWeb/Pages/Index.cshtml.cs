using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Pages.Views;
using PokedexWeb.Services;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PokedexWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PokeApiService _pokeApiService;
        private readonly TipoService _tipoService;

        public IndexModel(ILogger<IndexModel> logger, PokeApiService pokeApiService, TipoService tipoService)
        {
            _logger = logger;
            _pokeApiService = pokeApiService;
            _tipoService = tipoService;
        }


        public async Task OnGetAsync()
        {
            IEnumerable<TipoModel> typesDb = Enumerable.Empty<TipoModel>(); ;

            try
            {
                typesDb = _tipoService.GetTipos();

                if (typesDb != null && typesDb.Count() <= 0)
                {
                    var dataTypes = await _pokeApiService.GetAllAbilities();
                    var types = dataTypes.RootElement.GetProperty("results");

                    foreach (var type in types.EnumerateArray())
                    {
                        string typeName = type.GetProperty("name").GetString();

                        string typeUrl = type.GetProperty("url").GetString();

                        string idType = typeUrl.Replace("https://pokeapi.co/api/v2/ability/", "");
                        idType = idType.Replace("/", "");

                        TipoModel tipoModel = new TipoModel();
                        tipoModel.id_tipo = Int32.Parse(idType);
                        tipoModel.nombre = typeName;

                        var added = _tipoService.AddTipo(tipoModel);

                        System.Diagnostics.Debug.WriteLine(added);
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return;
            }

            




            //var dataAbilities = await _pokeApiService.GetAllAbilities();
            //var abilities = dataAbilities.RootElement.GetProperty("results");
            //foreach (var ability in abilities.EnumerateArray())
            //{

            //    string abilityName = ability.GetProperty("name").GetString();

            //    System.Diagnostics.Debug.WriteLine(abilityName);
            //}



            //var data = await _pokeApiService.GetAllPokemonesFirstLoad();
            // var pokemones = data.RootElement.GetProperty("results");

            // foreach (var pokemon in pokemones.EnumerateArray())
            // {

            //     string url = pokemon.GetProperty("url").GetString();

            //     var detailPokemon = await _pokeApiService.GetPokemonFromUrl(url);

            //     System.Diagnostics.Debug.WriteLine($"name: {detailPokemon.RootElement.GetProperty("name")}");
            // }
        }
    }
}
