using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Helpers;
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
        private readonly TipoHelperIntialLoad _tipoHelperIntialLoad;
        private readonly HabilidadHelperInitialLoad _habilidadHelperInitialLoad;

        public IndexModel(ILogger<IndexModel> logger, TipoHelperIntialLoad tipoHelperIntialLoad, HabilidadHelperInitialLoad habilidadHelperInitialLoad)
        {
            _logger = logger;
            _tipoHelperIntialLoad = tipoHelperIntialLoad;
            _habilidadHelperInitialLoad = habilidadHelperInitialLoad;
        }


        public async Task OnGetAsync()
        {
            await _tipoHelperIntialLoad.InitialLoadTipos();

            await _habilidadHelperInitialLoad.InitialLoadTipos();

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
