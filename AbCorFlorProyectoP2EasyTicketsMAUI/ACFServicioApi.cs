using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFlorProyectoP2EasyTicketsMAUI
{
    public class ACFServicioApi
    {
        private readonly HttpClient _httpClient;

        public ACFServicioApi()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ACFApiSettings.EventosApiBaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("x-api-key", ACFApiSettings.ApiKey);
        }

        public async Task<List<ACFEventos>> GetEventoAsync()
        {
            var response = await _httpClient.GetAsync("events?apikey=XgPqW8QqrmJVZEPAe9crwndjAigWzoft");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<ACFRoot>(json);
                return rootObject?.Embedded?.Events ?? new List<ACFEventos>();
            }
            return new List<ACFEventos>();
        }

    }
}
