namespace AbCorFlorProyectoP2EasyTicketsMAUI.Views;

public partial class ACFEventosGuardados : ContentPage
{
	public ACFEventosGuardados()
	{
		InitializeComponent();
	}
    private void OnEventSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            ((CollectionView)sender).SelectedItem = null; // Deselecciona el evento.
        }
    }

}