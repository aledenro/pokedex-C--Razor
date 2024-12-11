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
        private readonly PokemonHelperInitialLoad _pokemonHelperInitialLoad;

        public IndexModel(ILogger<IndexModel> logger, TipoHelperIntialLoad tipoHelperIntialLoad, HabilidadHelperInitialLoad habilidadHelperInitialLoad, PokemonHelperInitialLoad pokemonHelperInitialLoad)
        {
            _logger = logger;
            _tipoHelperIntialLoad = tipoHelperIntialLoad;
            _habilidadHelperInitialLoad = habilidadHelperInitialLoad;
            _pokemonHelperInitialLoad = pokemonHelperInitialLoad;
        }


        public async Task OnGetAsync()
        {
            await _tipoHelperIntialLoad.InitialLoadTipos();

            await _habilidadHelperInitialLoad.InitialLoadTipos();

            await _pokemonHelperInitialLoad.InitialLoadPokemones();
        }
    }
}
