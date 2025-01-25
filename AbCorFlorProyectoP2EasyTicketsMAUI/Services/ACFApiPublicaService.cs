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
                // Construir la URL de la API con la clave API
                string requestUrl = $"{EventosApiBaseUrl}.json?apikey={ApiKey}";

                // Realizar la solicitud HTTP GET
                var response = await _httpClient.GetStringAsync(requestUrl);

                // Deserializar la respuesta JSON a un objeto ACFRoot
                var root = JsonConvert.DeserializeObject<ACFRoot>(response);

                // Verificar si se obtuvieron eventos
                if (root?.Embedded?.Events != null)
                {
                    return root.Embedded.Events;
                }

                // Si no hay eventos, devolver una lista vacía
                return new List<ACFEventos>();
            }
            catch (Exception ex)
            {
                // Manejar errores (puedes loguear el error o mostrar un mensaje)
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

