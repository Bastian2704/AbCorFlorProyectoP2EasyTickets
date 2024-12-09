using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AbCorFlorProyectoP2EasyTicketsMAUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
         
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7135/api/")
                };

                var response = await client.GetAsync("ACFTicket");

                if (response.IsSuccessStatusCode)
                {
                    var ACFTickets = await response.Content.ReadAsStringAsync();

                    var ACFTicketsList = JsonConvert.DeserializeObject<List<ACFTicket>>(ACFTickets);

                    var availableTickets = ACFTicketsList.Where(ticket => !ticket.ACFVendido).ToList();

                    TicketsCollectionView.ItemsSource = availableTickets;
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los tickets disponibles.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }

    }

}
