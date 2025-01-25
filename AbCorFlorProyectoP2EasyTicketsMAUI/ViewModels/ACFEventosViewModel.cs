using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
using AbCorFlorProyectoP2EasyTicketsMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace AbCorFlorProyectoP2EasyTicketsMAUI.ViewModels
{
    public class ACFEventosViewModel : INotifyPropertyChanged
    {
        private readonly ACFApiPublicaService _apiService;
        public ObservableCollection<ACFEventos> Eventos { get; set; } = new();

        private bool _cargando;
        public bool Cargando
        {
            get => _cargando;
            set
            {
                if (_cargando != value)
                {
                    _cargando = value;
                    OnPropertyChanged();
                }
            }
        }

        public ACFEventosViewModel()
        {
            _apiService = new ACFApiPublicaService(); // Inicializa el servicio de API
            CargarEventos(); // Carga los eventos al inicializar el ViewModel
        }

        private async void CargarEventos()
        {
            Cargando = true; // Indica que la carga está en progreso

            try
            {
                // Obtiene los eventos desde la API
                var eventos = await _apiService.GetEventosAsync();

                // Limpia la lista actual y agrega los nuevos eventos
                Eventos.Clear();
                foreach (var evento in eventos)
                {
                    Eventos.Add(evento);
                }
            }
            catch (Exception ex)
            {
                // Maneja errores (puedes mostrar un mensaje al usuario o loguear el error)
                Console.WriteLine($"Error al cargar eventos: {ex.Message}");
            }
            finally
            {
                Cargando = false; // Indica que la carga ha terminado
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
