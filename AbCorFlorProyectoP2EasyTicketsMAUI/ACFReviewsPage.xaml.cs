using Newtonsoft.Json;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;


namespace AbCorFlorProyectoP2EasyTicketsMAUI;

public partial class ACFReviewsPage : ContentPage
{
	public ACFReviewsPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7135/api/");
        var response = client.GetAsync("ACFReviews").Result;

        if (response.IsSuccessStatusCode)
        {
            var ACFReview = response.Content.ReadAsStringAsync().Result;
            var ACFReviewsList = JsonConvert.DeserializeObject<List<ACFReviews>>(ACFReview);
            ReviewsCollectionView.ItemsSource = ACFReviewsList.ToList();

        }
    }
}