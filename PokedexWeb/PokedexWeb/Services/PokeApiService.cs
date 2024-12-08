using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace PokedexWeb.Services
{
    public class PokeApiService
    {

        private readonly HttpClient _httpClient;

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JsonDocument> GetAllPokemonesFirstLoad()
        {
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=-1");

            var content = await response.Content.ReadAsStringAsync();

            return JsonDocument.Parse(content);
        }

        public async Task<JsonDocument> GetPokemonFromUrl(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return JsonDocument.Parse(content);

        }
    }
}
