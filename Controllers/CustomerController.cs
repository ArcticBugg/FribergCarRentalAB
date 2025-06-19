using Microsoft.AspNetCore.Mvc;
using FribergCarRentalAB.Data;
using FribergCarRentalAB.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalAB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToAction("Index", "Login");

            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            return View(customer);
        }

        public IActionResult Bookings()
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToAction("Index", "Login");

            var bookings = _context.Bookings
     .Include(b => b.Car)
     .Include(b => b.Customer)
     .Where(b => b.CustomerId == customerId)
     .ToList();


            return View(bookings);
        }

        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }

            return RedirectToAction("Bookings");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
