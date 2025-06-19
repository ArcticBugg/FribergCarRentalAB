using Microsoft.AspNetCore.Mvc;
using FribergCarRentalAB.Models;
using FribergCarRentalAB.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FribergCarRentalAB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // innehåller login + registreringsformulär
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer != null)
            {
                HttpContext.Session.SetInt32("CustomerId", customer.Id);
                return RedirectToAction("Index", "Customer");
            }

            ViewBag.Error = "Fel mejl eller lösenord.";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password, string address, string PhoneNumber)
        {
            if (_context.Customers.Any(c => c.Email == email))
            {
                ViewBag.Error = "Mejlen är redan registrerad.";
                return View("Index");
            }

            var newCustomer = new Customer 
            { 
                Name = name, 
                Email = email, 
                Password = password,
                Address = address,
                PhoneNumber = PhoneNumber
            };
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("CustomerId", newCustomer.Id);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
