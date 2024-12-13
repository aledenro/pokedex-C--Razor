using PokedexWeb.Models;
using PokedexWeb.Services;

namespace PokedexWeb.Helpers
{
    public class TipoHelperIntialLoad
    {
        private readonly PokeApiService _pokeApiService;
        private readonly TipoService _tipoService;

        public TipoHelperIntialLoad(PokeApiService pokeApiService, TipoService tipoService)
        {
            _pokeApiService = pokeApiService;
            _tipoService = tipoService;
        }


        public async Task InitialLoadTipos()
        {
            IEnumerable<TipoModel> typesDb = Enumerable.Empty<TipoModel>(); ;

            try
            {
                typesDb = _tipoService.GetTipos();

                if (typesDb != null && typesDb.Count() <= 0)
                {
                    var dataTypes = await _pokeApiService.GetAllTypes();
                    var types = dataTypes.RootElement.GetProperty("results");

                    foreach (var type in types.EnumerateArray())
                    {
                        string typeName = type.GetProperty("name").GetString();

                        string typeUrl = type.GetProperty("url").GetString();

                        string idType = typeUrl.Replace("https://pokeapi.co/api/v2/type/", "");
                        idType = idType.Replace("/", "");

                        TipoModel tipoModel = new TipoModel();
                        tipoModel.id_tipo = Int32.Parse(idType);
                        tipoModel.nombre = typeName;

                        var added = _tipoService.AddTipo(tipoModel);

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
