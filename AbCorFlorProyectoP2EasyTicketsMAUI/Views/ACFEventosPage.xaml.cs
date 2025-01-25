namespace AbCorFlorProyectoP2EasyTicketsMAUI.Views;
using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
public partial class ACFEventosPage : ContentPage
{
	public ACFEventosPage()
	{
		InitializeComponent();
	}
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var evenSelec = e.CurrentSelection[0] as ACFEventos;
            if (evenSelec != null)
            {
                var ACFDetallesView = new ACFDetallesView();
                var EventosDetallesViewModel = (ACFEventosDetallesViewModel)ACFDetallesView.BindingContext;
                EventosDetallesViewModel.initialize(evenSelec);
                await Navigation.PushAsync(ACFDetallesView);
            }
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}