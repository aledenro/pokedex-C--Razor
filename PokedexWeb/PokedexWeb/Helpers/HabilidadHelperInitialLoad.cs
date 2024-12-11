using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Helpers
{
    public class HabilidadHelperInitialLoad
    {
        private readonly PokeApiService _pokeApiService;
        private readonly HabilidadService _habilidadService;

        public HabilidadHelperInitialLoad(PokeApiService pokeApiService, HabilidadService habilidadService)
        {
            _pokeApiService = pokeApiService;
            _habilidadService = habilidadService;
        }


        public async Task InitialLoadTipos()
        {
            IEnumerable<HabilidadModel> abilitiesDb = Enumerable.Empty<HabilidadModel>(); ;

            try
            {
                abilitiesDb = _habilidadService.GetHabilidades();

                if (abilitiesDb != null && abilitiesDb.Count() <= 0)
                {
                    var dataAbilities = await _pokeApiService.GetAllAbilities();
                    var abilities = dataAbilities.RootElement.GetProperty("results");

                    foreach (var ability in abilities.EnumerateArray())
                    {
                        string abilityName = ability.GetProperty("name").GetString();

                        string abilityUrl = ability.GetProperty("url").GetString();

                        string idAbility = abilityUrl.Replace("https://pokeapi.co/api/v2/ability/", "");
                        idAbility = idAbility.Replace("/", "");

                        HabilidadModel habilidadModel = new HabilidadModel();
                        habilidadModel.id_habilidad = Int32.Parse(idAbility);
                        habilidadModel.nombre = abilityName;

                        var added = _habilidadService.AddHabilidad(habilidadModel);

                        System.Diagnostics.Debug.WriteLine(added);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return;
            }
        }
    }
}

