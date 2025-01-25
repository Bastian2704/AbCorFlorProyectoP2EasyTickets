using Newtonsoft.Json;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;

namespace AbCorFlorProyectoP2EasyTicketsMAUI;

public partial class ACFReviewsPage : ContentPage
{
    private readonly ACFReviewsViewModel _viewModel;
    public ACFReviewsPage()
	{
		InitializeComponent();
        BindingContext = _viewModel = new ACFReviewsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadReviewsCommand.Execute(null);
    }
}