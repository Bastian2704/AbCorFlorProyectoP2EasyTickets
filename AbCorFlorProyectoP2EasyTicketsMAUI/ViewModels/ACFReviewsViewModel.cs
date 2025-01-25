using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels
{
    public  class ACFReviewsViewModel : ACFPrincipalViewModel
    {
        private ObservableCollection<ACFReviews> _reviews;
        public ObservableCollection<ACFReviews> Reviews
        {
            get => _reviews;
            set => SetProperty(ref _reviews, value);
        }

        public Command LoadReviewsCommand { get; }

        public ACFReviewsViewModel()
        {
            Reviews = new ObservableCollection<ACFReviews>();
            LoadReviewsCommand = new Command(async () => await LoadReviewsAsync());
        }

        private async Task LoadReviewsAsync()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7135/api/")
                };

                var response = await client.GetAsync("ACFReviews");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Contenido de la respuesta: {content}");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    var reviewsList = JsonSerializer.Deserialize<List<ACFReviews>>(content, options);

                    if (reviewsList != null)
                    {
                        Debug.WriteLine($"Reviews obtenidos: {reviewsList.Count}");
                        foreach (var review in reviewsList)
                        {
                            Debug.WriteLine($"Comentario: {review.ACFComentario}, Fecha: {review.ACFFecha}, Calificación: {review.ACFCalificacion}, Evento:{review.ACFTicketID}");
                        }

                        Reviews.Clear();
                        foreach (var review in reviewsList)
                        {
                            Reviews.Add(review);
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
