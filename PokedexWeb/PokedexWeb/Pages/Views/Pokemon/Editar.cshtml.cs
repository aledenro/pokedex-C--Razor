using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Pages.Views.Pokemon
{
    public class EditarModel : PageModel
    {
        private readonly TipoService _tipoService;
        private readonly HabilidadService _habilidadService;
        private readonly PokemonService _pokemonService;
        private readonly PokemonTipoService _pokemonTipoService;
        private readonly PokemonHabilidadService _pokemonHabilidadService;

        public EditarModel(TipoService tipoService, HabilidadService habilidadService, PokemonService pokemonService, PokemonTipoService pokemonTipoService, PokemonHabilidadService pokemonHabilidadService)
        {
            _tipoService = tipoService;
            _habilidadService = habilidadService;
            _pokemonService = pokemonService;
            _pokemonTipoService = pokemonTipoService;
            _pokemonHabilidadService = pokemonHabilidadService;
        }

        [BindProperty]
        public PokemonModel Pokemon { get; set; }

        [BindProperty]
        public List<int> IdsTipos { get; set; } = new List<int>();

        [BindProperty]
        public List<int> IdsHabilidades { get; set; } = new List<int>();

        public IEnumerable<TipoModel> Tipos { get; set; }
        public IEnumerable<HabilidadModel> Habilidades { get; set; }

        public string Message { get; set; }

        public void OnGet([FromQuery(Name = "id")] string id)
        {
            Pokemon = _pokemonService.GetPokemon(Int32.Parse(id));

            Tipos = _tipoService.GetTipos();
            Habilidades = _habilidadService.GetHabilidades();

            if (Pokemon.PokemonTipos != null)
            {
                foreach (var tipo in Pokemon.PokemonTipos)
                {
                    if (tipo.Tipo != null)
                    {
                        IdsTipos.Add(tipo.Tipo.id_tipo);
                    }
                }
            }

            if (Pokemon.PokemonHabilidades != null)
            {
                foreach (var habilidad in Pokemon.PokemonHabilidades)
                {
                    if (habilidad.Habilidad != null)
                    {
                        IdsTipos.Add(habilidad.Habilidad.id_habilidad);
                    }
                }
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _pokemonService.EditPokemon(Pokemon);

                _pokemonTipoService.DeletePokemonTipo(Pokemon.id_pokemon);

                foreach (int idTipo in IdsTipos)
                {
                    PokemonTipoModel model = new PokemonTipoModel();
                    model.id_pokemon = Pokemon.id_pokemon;
                    model.id_tipo = idTipo;

                    _pokemonTipoService.AddPokemonTipo(model);
                }

                _pokemonHabilidadService.DeletePokemonHabilidad(Pokemon.id_pokemon);

                foreach (int idHab in IdsHabilidades)
                {
                    PokemonHabilidadModel model = new PokemonHabilidadModel();
                    model.id_pokemon = Pokemon.id_pokemon;
                    model.id_habilidad = idHab;

                    _pokemonHabilidadService.AddPokemonHabilidad(model);
                }

                return RedirectToPage("/Views/Pokemon/Index");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Message = "Error al editar el Pokemon. Trate nuevamente";
                return Page();
            }
        }
    }
}
