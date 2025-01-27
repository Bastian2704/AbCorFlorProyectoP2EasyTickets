using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Services
{
    internal class ACFApiPublicaService
    {
        private readonly HttpClient _httpClient;
        private const string EventosApiBaseUrl = "https://app.ticketmaster.com/discovery/v2/events";
        private const string ApiKey = "XgPqW8QqrmJVZEPAe9crwndjAigWzoft";

        public ACFApiPublicaService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ACFEventos>> GetEventosAsync()
        {
            try
            {
                string requestUrl = $"{EventosApiBaseUrl}.json?apikey={ApiKey}";

                var response = await _httpClient.GetStringAsync(requestUrl);

                var root = JsonConvert.DeserializeObject<ACFRoot>(response);

                if (root?.Embedded?.Events != null)
                {
                    return root.Embedded.Events;
                }

                return new List<ACFEventos>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching events: {ex.Message}");
                return new List<ACFEventos>();
            }
        }
    }
    public class ACFRoot
    {
        [JsonProperty("_embedded")]
        public ACFEmbedded Embedded { get; set; }

        public ACFRoot()
        {
            Embedded = new ACFEmbedded
            {
                Events = new List<ACFEventos>()
            };
        }
    }

    public class ACFEmbedded
    {
        [JsonProperty("events")]
        public List<ACFEventos> Events { get; set; }
    }
}

