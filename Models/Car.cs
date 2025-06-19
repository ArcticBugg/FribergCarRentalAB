using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalAB.Models
{
    //Representerar en bil i systemet
    public class Car
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Märke är obligatoriskt")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Modell är obligatoriskt")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        [StringLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Dagshyra är obligatoriskt")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Regnummer är obligatoriskt")]
        public string RegistrationNumber { get; set; } = null;

        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
