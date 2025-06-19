using Microsoft.AspNetCore.Mvc;
using FribergCarRentalAB.Data;
using FribergCarRentalAB.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FribergCarRentalAB.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        public IActionResult Book(int carId, DateTime startDate, DateTime endDate)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToAction("Index", "Login");

            var booking = new Booking
            {
                CarId = carId,
                CustomerId = customerId.Value,
                StartDate = startDate,
                EndDate = endDate
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Bookings", "Customer");
        }
    }
}
