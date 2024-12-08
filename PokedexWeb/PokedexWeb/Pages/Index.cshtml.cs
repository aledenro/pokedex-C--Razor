using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Pages.Views;
using PokedexWeb.Services;
using System.Net.WebSockets;

namespace PokedexWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PokeApiService _pokeApiService;

        public IndexModel(ILogger<IndexModel> logger, PokeApiService pokeApiService)
        {
            _logger = logger;
            _pokeApiService = pokeApiService;
        }
        

        public async void OnGet()
        {
           var data = await _pokeApiService.GetAllPokemonesFirstLoad();
            var pokemones = data.RootElement.GetProperty("results");

            foreach (var pokemon in pokemones.EnumerateArray())
            {
                
                string url = pokemon.GetProperty("url").GetString();

                var detailPokemon = await _pokeApiService.GetPokemonFromUrl(url);

                System.Diagnostics.Debug.WriteLine($"name: {detailPokemon.RootElement.GetProperty("name")}");
            }
        }
    }
}
