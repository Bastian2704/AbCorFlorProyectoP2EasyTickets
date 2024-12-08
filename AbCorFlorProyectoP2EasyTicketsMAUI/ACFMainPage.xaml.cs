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

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7135/api/");
            var response = client.GetAsync("ACFTicket").Result;

            if (response.IsSuccessStatusCode)
            {
                var ACFTickets = response.Content.ReadAsStringAsync().Result;
                var ACFTicketsList = JsonConvert.DeserializeObject<List<ACFTicket>>(ACFTickets);
                TicketsCollectionView.ItemsSource = ACFTicketsList;
            }
        }


    }

}
