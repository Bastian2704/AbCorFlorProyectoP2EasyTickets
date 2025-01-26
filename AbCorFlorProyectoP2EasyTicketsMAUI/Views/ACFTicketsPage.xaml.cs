namespace AbCorFlorProyectoP2EasyTicketsMAUI.Views;
using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;

public partial class ACFTicketsPage : ContentPage
{
    private readonly ACFTicketViewModel _viewModel;
    public ACFTicketsPage()
	{
		InitializeComponent();
        BindingContext = _viewModel = new ACFTicketViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadTicketsCommand.Execute(null);
    }
}