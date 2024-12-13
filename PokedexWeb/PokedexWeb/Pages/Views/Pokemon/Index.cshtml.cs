using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Pokemon
{
    public class IndexModel : PageModel
    {
        private readonly PokemonService _pokemonService;

        public IndexModel(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public IEnumerable<PokemonModel> Pokemones { get; set; }

        public async Task OnGet()
        {
            Pokemones = _pokemonService.GetPokemones();
        }
    }
}
