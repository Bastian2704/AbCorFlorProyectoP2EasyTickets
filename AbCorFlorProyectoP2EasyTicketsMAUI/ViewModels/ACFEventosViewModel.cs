using AbCorFlorProyectoP2EasyTicketsMAUI.Models;
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
        private readonly ACFServicioApi _ACFServicioAPI;
        public ObservableCollection<ACFEventos> Eventos { get; set; } = new();

        private bool _cargando;
        public bool Cargando
        {
            get => _cargando;
            set
            {
                _cargando = value;
                OnPropertyChanged();
            }
        }

        public ACFEventosViewModel()
        {
            _ACFServicioAPI = new ACFServicioApi();
            cargarEvento();
        }

        private async void cargarEvento()
        {
            Cargando = true;
            var events = await _ACFServicioAPI.GetEventoAsync();
            Eventos.Clear();
            foreach (var even in events)
            {
                Eventos.Add(even);
            }
            Cargando = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
