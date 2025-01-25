namespace AbCorFlorProyectoP2EasyTicketsMAUI.Views;
using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
public partial class ACFEventosPage : ContentPage
{
	public ACFEventosPage()
	{
		InitializeComponent();
        BindingContext = new ACFEventosViewModel();
    }
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var evenSelec = e.CurrentSelection[0] as ACFEventos; 
            if (evenSelec != null)
            {
                var detallesView = new ACFDetallesView();
                var detallesViewModel = (ACFEventosDetallesViewModel)detallesView.BindingContext;
                detallesViewModel.Initialize(evenSelec);
                await Navigation.PushAsync(detallesView);
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}