using FribergCarRentalAB.Data;
using FribergCarRentalAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// AdminController hanterar alla admin-funktioner via /admin

[Route("admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // Visa adminöversikt direkt
        return RedirectToAction("Dashboard");
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        return View(); 
    }

    
    [HttpGet("cars")]
    public IActionResult Cars() => View(_context.Cars.ToList());

    [HttpGet("cars/create")]
    public IActionResult CreateCar() => View();

    [HttpPost("cars/create")]
    public IActionResult CreateCar(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
        return RedirectToAction("Cars");
    }

    [HttpGet("cars/edit/{id}")]
    public IActionResult EditCar(int id) => View(_context.Cars.Find(id));

    [HttpPost("cars/edit/{id}")]
    public IActionResult EditCar(Car car)
    {
        _context.Cars.Update(car);
        _context.SaveChanges();
        return RedirectToAction("Cars");
    }

    [HttpGet("cars/delete/{id}")]
    public IActionResult DeleteCar(int id)
    {
        var car = _context.Cars.Find(id);
        _context.Cars.Remove(car);
        _context.SaveChanges();
        return RedirectToAction("Cars");
    }

    // CRUD för kunder
    [HttpGet("customers")]
    public IActionResult Customers() => View(_context.Customers.ToList());

    [HttpGet("customers/edit/{id}")]
    public IActionResult EditCustomer(int id) => View(_context.Customers.Find(id));

    [HttpPost("customers/edit/{id}")]
    public IActionResult EditCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return RedirectToAction("Customers");
    }

    [HttpGet("customers/delete/{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
        return RedirectToAction("Customers");
    }

    // Bokningar
    [HttpGet("bookings")]
    public IActionResult Bookings()
    {
        var bookings = _context.Bookings
            .Include(b => b.Car)
            .Include(b => b.Customer)
            .ToList();
        return View(bookings);
    }

    [HttpGet("bookings/delete/{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var booking = _context.Bookings.Find(id);
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return RedirectToAction("Bookings");
    }

    [HttpPost("bookings/confirm/{id}")]
    public IActionResult ConfirmBooking(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null) return NotFound();

        booking.Confirmed = true;
        _context.SaveChanges();
        return RedirectToAction("Bookings");
    }
}
