using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using AbCorFlorProyectoP2EasyTicketsMAUI.Services;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels
{
    public class ACFEventosDetallesViewModel : INotifyPropertyChanged
    {
        private ACFEventos _eventos;
        public ACFEventos Eventos
        {
            get => _eventos;
            set
            {
                _eventos = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        private readonly ACFDataService _dataService;

        public ACFEventosDetallesViewModel()
        {
            _dataService = new ACFDataService();

            GuardarCommand = new Command(OnGuardar);
            CancelarCommand = new Command(OnCancelar);
        }

        public void Initialize(ACFEventos eventoSeleccionado)
        {
            Eventos = eventoSeleccionado ?? new ACFEventos(); 
        }

        private async void OnGuardar()
        {
            if (Eventos != null)
            {
                await _dataService.SaveEventAsync(Eventos);
                await Application.Current.MainPage.DisplayAlert("Éxito", "Evento guardado correctamente.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay un evento para guardar.", "OK");
            }
        }

        private void OnCancelar()
        {
            Eventos = null;
            Application.Current.MainPage.Navigation.PopAsync(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
