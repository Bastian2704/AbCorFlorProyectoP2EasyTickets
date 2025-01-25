using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Models
{
    public class ACFReviews
    {
        public int ACFReviewID { get; set; }
        public string ACFComentario { get; set; }
        public int ACFCalificacion { get; set; }
        public DateTime ACFFecha { get; set; }
        public int ACFTicketID { get; set; }
        public ACFTicket ACFTicket { get; set; }
    }
}
