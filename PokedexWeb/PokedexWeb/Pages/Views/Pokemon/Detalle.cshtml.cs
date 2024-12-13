using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Pokemon
{
    public class DetalleModel : PageModel
    {

        private readonly PokemonService _pokemonService;

        public DetalleModel(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public PokemonModel Pokemon {  get; set; }

        public void OnGet([FromQuery(Name = "id")] string id)
        {
            Pokemon = _pokemonService.GetPokemon(Int32.Parse(id));
            Pokemon.foto = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Pokemon.id_pokemon}.png";
        }
    }
}
