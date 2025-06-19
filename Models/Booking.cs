using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalAB.Models
{
    //Bokning av en bil för en kund under en viss tid.
    public class Booking
    {
        public int Id { get; set; }

        //Vilken bil som bokats.
        [Required(ErrorMessage = "Bil är obligatoriskt")]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        //Vem som bokat.
        [Required(ErrorMessage = "Kund är obligatoriskt")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        [Required(ErrorMessage = "Startdatum är obligatoriskt")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Slutdatum är obligatoriskt")]
        public DateTime EndDate { get; set; }

        //Anger om bokningen är bekräftad eller ej.
        public bool Confirmed { get; set; } = false;
    }
}
