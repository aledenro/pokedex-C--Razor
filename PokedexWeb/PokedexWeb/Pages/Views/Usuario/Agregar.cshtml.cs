using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Usuario
{
    public class AgregarModel : PageModel
    {

        private readonly PokemonService _pokemonService;
        private readonly UsuarioPokemonService _usuarioPokemonService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AgregarModel(PokemonService pokemonService, IHttpContextAccessor httpContextAccessor, UsuarioPokemonService usuarioPokemonService)
        {
            _pokemonService = pokemonService;
            _usuarioPokemonService = usuarioPokemonService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<PokemonModel>  Pokemones { get; set; }

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public int IdPokemon {  get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            Pokemones = _pokemonService.GetPokemones();
        }

        public IActionResult OnPost() {
            string id_usuario = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            if(_usuarioPokemonService.existeEquipo(Int32.Parse(id_usuario), IdPokemon))
            {
                Message = "Ya existe el pokemon  en su equipo.";
                return RedirectToPage();
            }

            bool agregado = _usuarioPokemonService.AddPokemonUsuario(Int32.Parse(id_usuario), IdPokemon, Nombre);

            if (!agregado)
            {
                Message = "Error al asignar el pokemon a sus equipo.";
                return RedirectToPage();
            }

            return RedirectToPage("/Views/Usuario/Equipo");
        }
    }
}
