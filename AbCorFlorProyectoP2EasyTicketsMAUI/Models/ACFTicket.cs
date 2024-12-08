using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Models
{
    internal class ACFTicket
    {
        public int ACFTicketID { get; set; }
        public string ACFEvento { get; set; }
        public DateTime ACFFecha { get; set; }
        public string ACFLugar { get; set; }
        public string ACFButacaSeccion { get; set; }
        public decimal ACFPrecio { get; set; }
        public string ACFTelefono { get; set; }
        public bool ACFVendido { get; set; }
        public string ACFContrasenia { get; set; }
        public object reviewss { get; set; }
    }
}
