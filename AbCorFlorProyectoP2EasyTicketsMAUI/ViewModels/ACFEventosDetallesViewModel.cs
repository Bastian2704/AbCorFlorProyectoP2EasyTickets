using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;

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

        public ACFEventosDetallesViewModel()
        {

        }
        public void initialize(ACFEventos evenSelec)
        {
            Eventos = evenSelec;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
