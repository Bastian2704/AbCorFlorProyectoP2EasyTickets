using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using System.Diagnostics;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels
{
    public class ACFTicketViewModel : ACFPrincipalViewModel
    {
        private ObservableCollection<ACFTicket> _tickets;
        public ObservableCollection<ACFTicket> Tickets
        {
            get => _tickets;
            set => SetProperty(ref _tickets, value);
        }

        public Command LoadTicketsCommand { get; }

        public ACFTicketViewModel()
        {
            Tickets = new ObservableCollection<ACFTicket>();
            LoadTicketsCommand = new Command(async () => await LoadTicketsAsync());
        }

        private async Task LoadTicketsAsync()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7135/api/")
                };

                var response = await client.GetAsync("ACFTicket");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Contenido de la respuesta: {content}");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    var ticketsList = JsonSerializer.Deserialize<List<ACFTicket>>(content, options);

                    if (ticketsList != null)
                    {
                        Debug.WriteLine($"Tickets obtenidos: {ticketsList.Count}");
                        foreach (var ticket in ticketsList)
                        {
                            Debug.WriteLine($"Evento: {ticket.ACFEvento}, Fecha: {ticket.ACFFecha}, Lugar: {ticket.ACFLugar}");
                        }

                        var availableTickets = ticketsList.Where(ticket => !ticket.ACFVendido).ToList();
                        Debug.WriteLine($"Tickets disponibles: {availableTickets.Count}");

                        Tickets.Clear();
                        foreach (var ticket in availableTickets)
                        {
                            Tickets.Add(ticket);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine($"Error en la respuesta de la API: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al cargar los tickets: {ex.Message}");
            }
        }

    }
}

