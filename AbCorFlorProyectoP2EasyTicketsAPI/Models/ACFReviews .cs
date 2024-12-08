using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEasyTicket.Models
{
    public class ACFReviews
    {
        //hola
        [Key]
        public int ACFReviewID { get; set; }
        [StringLength(500)]
        public string? ACFComentario { get; set; } // Comentario del usuario sobre el evento o el ticket

        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Range(1, 5)] // Establecer que la calificación debe estar entre 1 y 5 estrellas
        public int ACFCalificacion { get; set; } // Calificación (de 1 a 5)

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime ACFFecha { get; set; } = DateTime.Now; // Fecha en la que se hizo la reseña

        public int ACFTicketID { get; set; }

        public ACFTicket? ACFTicket { get; set; }

    }
}
    