using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

using AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels;

namespace AbCorFlorProyectoP2EasyTicketsMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly ACFTicketViewModel _viewModel;

        public MainPage()
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

}
