using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalAB.Models
{

    //Klass som representerar en kund som kan hyra bilar.
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn är obligatoriskt")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Adress är obligatoriskt")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Telefonnummer är obligatoriskt")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Mejl är obligatoriskt")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Lösenord är obligatoriskt")]
        public string Password { get; set; } = null!;

        public List<Booking> Bookings { get; set; } = new();
    }
}
