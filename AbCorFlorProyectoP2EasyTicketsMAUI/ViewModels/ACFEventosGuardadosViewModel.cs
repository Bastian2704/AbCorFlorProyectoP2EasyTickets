using AbCorFlorProyectoP2EasyTicketsMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using AbCorFlorProyectoP2EasyTicketsMAUI.Views;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels
{
    public class ACFEventosGuardadosViewModel : INotifyPropertyChanged
    {
        private readonly ACFDataService _dataService;
        private bool _cargando;

        public ObservableCollection<ACFEventos> EventosGuardados { get; set; } = new();

        public bool Cargando
        {
            get => _cargando;
            set
            {
                _cargando = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand RefrescarCommand { get; }

        public ACFEventosGuardadosViewModel()
        {
            _dataService = new ACFDataService();
            EditarCommand = new Command<ACFEventos>(OnEditar);
            EliminarCommand = new Command<ACFEventos>(OnEliminar);
            RefrescarCommand = new Command(CargarEventosGuardados);
            CargarEventosGuardados();
        }

        private async void CargarEventosGuardados()
        {
            Cargando = true;

            try
            {
                var eventos = await _dataService.GetEventsAsync();
                EventosGuardados.Clear();
                foreach (var evento in eventos)
                {
                    EventosGuardados.Add(evento);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los eventos guardados: {ex.Message}");
            }
            finally
            {
                Cargando = false;
            }
        }

        private async void OnEditar(ACFEventos evento)
        {
            var detallesView = new ACFDetallesView();
            var detallesViewModel = (ACFEventosDetallesViewModel)detallesView.BindingContext;
            detallesViewModel.Initialize(evento);
            await Application.Current.MainPage.Navigation.PushAsync(detallesView);
        }

        private async void OnEliminar(ACFEventos evento)
        {
            if (evento != null)
            {
                var confirm = await Application.Current.MainPage.DisplayAlert(
                    "Confirmar",
                    "¿Estás seguro de que deseas eliminar este evento?",
                    "Sí",
                    "No");

                if (confirm)
                {
                    await _dataService.DeleteEventAsync(evento);
                    EventosGuardados.Remove(evento);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
