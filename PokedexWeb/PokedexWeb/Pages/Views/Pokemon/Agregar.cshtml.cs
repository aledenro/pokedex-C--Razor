using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Pokemon
{
    public class AgregarModel : PageModel
    {
        private readonly TipoService _tipoService;
        private readonly HabilidadService _habilidadService;
        private readonly PokemonService _pokemonService;
        private readonly PokemonTipoService _pokemonTipoService;
        private readonly PokemonHabilidadService _pokemonHabilidadService;

        public AgregarModel(TipoService tipoService, HabilidadService habilidadService, PokemonService pokemonService, PokemonTipoService pokemonTipoService, PokemonHabilidadService pokemonHabilidadService)
        {
            _tipoService = tipoService;
            _habilidadService = habilidadService;
            _pokemonService = pokemonService;
            _pokemonTipoService = pokemonTipoService;
            _pokemonHabilidadService = pokemonHabilidadService;
        }

        [BindProperty]
        public PokemonModel Pokemon {  get; set; }

        public IEnumerable<TipoModel>  Tipos { get; set; }
        public IEnumerable<HabilidadModel> Habilidades { get; set; }

        [BindProperty]
        public List<int> IdsTipos { get; set; }

        [BindProperty]
        public List<int> IdsHabilidades { get; set; }

        public string Message { get; set; }


        public async Task OnGet()
        {
            Tipos = _tipoService.GetTipos();
            Habilidades = _habilidadService.GetHabilidades();
        }

        public IActionResult OnPost()
        {
            try
            {
                Pokemon.foto = "https://static.wikia.nocookie.net/pokemon/images/8/87/Pok%C3%A9_Ball.png/revision/latest?cb=20240922024755";

                Pokemon.id_pokemon = _pokemonService.GetMaxPokemonId() + 1;

                _pokemonService.AddPokemon(Pokemon);

                foreach (int idTipo in IdsTipos)
                {
                    PokemonTipoModel model = new PokemonTipoModel();
                    model.id_pokemon = Pokemon.id_pokemon;
                    model.id_tipo = idTipo;

                    _pokemonTipoService.AddPokemonTipo(model);
                }

                foreach (int idHab in IdsHabilidades)
                {
                    PokemonHabilidadModel model = new PokemonHabilidadModel();
                    model.id_pokemon = Pokemon.id_pokemon;
                    model.id_habilidad = idHab;

                    _pokemonHabilidadService.AddPokemonHabilidad(model);
                }

                return RedirectToPage("/Views/Pokemon/Index");

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Message = "Error al agregar Pokemon. Trate nuevamente";
                return Page();
            }
        }
    }
}
