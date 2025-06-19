using FribergCarRentalAB.Models;

namespace FribergCarRentalAB.Data
{
    //Klass som körs vid start och lägger in en bil med beskrivning och bilder, om databasen är tom.
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(

                    new Car
                    {
                        Brand = "LandRover",
                        Model = "Turbo Xtra Gold",
                        RegistrationNumber = "LUX007",
                        PricePerDay = 4999,
                        Description = "Rymd, lyx och klass.",
                        ImageUrls = new List<string>
                        {
                            "/images/LandRover1.jpg",
                            "/images/LandRover2.jpg"
                        }
                    }


                );

                context.SaveChanges();
            }
        }
    }
}
