using mml.CodeNames.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mml.CodeNames.Wpf.ViewModel.Helper
{
    public class HttpClientController
    {
        public HttpClient HttpClient { get; set; }
        public HttpClientController()
        {
            HttpClient = new HttpClient();
        }
        public async Task<List<Tiles>> StartNewGame()
        {
            var url = UrlConsts.GetNewGameUrl();            
            var response = await HttpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<List<Tiles>>(json, options);
        }

        public async Task<List<TileWords>> RetrieveDictionary()
        {
            var url = UrlConsts.GetTileLibraryUrl();            
            var response = await HttpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<List<TileWords>>(json, options);
        }
    }
}
