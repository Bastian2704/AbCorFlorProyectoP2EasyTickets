using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Views;

public partial class ACFReviewPage : ContentPage
{
    private readonly ACFReviewsViewModel _viewModel;
    public ACFReviewPage()
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