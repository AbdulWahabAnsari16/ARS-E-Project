using ARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ARS.Controllers
{
    public class AdminController : Controller
    {
        private readonly MainDbContext db;

        public AdminController(MainDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var list = db.Users.ToList();
            return View(list);
        }

        // City Section
        public IActionResult AddCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(City cities)
        {
            db.Cities.Add(cities);
            db.SaveChanges();
            //ViewBag.msg = "city inserted";
            return RedirectToAction("ViewCities");
        }
        public IActionResult ViewCities()
        {
            var list = db.Cities.ToList();
            return View(list);
        }
        public IActionResult EditCity(int? id)
        {
            var data = db.Cities.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCity(City city)
        {
            db.Cities.Update(city);
            db.SaveChanges();
            //ViewBag.msg = "updated";
            return RedirectToAction("ViewCities");
        }
        public IActionResult DeleteCity(int? id)
        {
            var data = db.Cities.Find(id);
            db.Cities.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ViewCities");
        }


        
        // Airport Section
        public IActionResult AddAirport()
        {
            var cities = db.Cities.ToList();
            ViewBag.cities = new SelectList(cities, "CityId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddAirport(Airport airport)
        {
            db.Airports.Add(airport);
            db.SaveChanges();
            //ViewBag.msg = "Inserted";
            return RedirectToAction("ViewAirports");
        }
        public IActionResult ViewAirports()
        {
            var list = db.Airports.Include(cities => cities.City);
            return View(list);
        }
        public IActionResult EditAirport(int? id)
        {
            var data = db.Airports.Find(id);
            var cities = db.Cities.ToList();
            ViewBag.cities = new SelectList(cities, "CityId", "Name");
            return View(data);
        }
        [HttpPost]
        public IActionResult EditAirport(Airport airport)
        {           
            db.Airports.Update(airport);
            db.SaveChanges();
            //ViewBag.msg = "updated";
            return RedirectToAction("ViewAirports");
        }
        public IActionResult DeleteAirport(int? id)
        {
            var data = db.Airports.Find(id);
            db.Airports.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ViewAirports");
        }

        // FlightRoutes Section
        public IActionResult AddFltRoute()
        {
            var airports = db.Airports.ToList();
            ViewBag.airport = new SelectList(airports, "AirportId", "IATACode");
            return View();
        }
        [HttpPost]
        public IActionResult AddFltRoute(FlightRoutes routes)
        {
            db.FlightRoutes.Add(routes);
            db.SaveChanges();
            ViewBag.msg = "Inserted";
            var airports = db.Airports.ToList();
            ViewBag.airport = new SelectList(airports, "AirportId", "IATACode");
            return View();
        }

        public IActionResult ViewFltRoutes()
        {
            var list = db.FlightRoutes.Include(airports => airports.OriginAirport);
            return View(list);
        }

        // Flight Section
        public IActionResult AddFlight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
            return RedirectToAction("VewFlights");
        }
        public IActionResult VewFlights()
        {
            var list = db.Flights.ToList();
            return View(list);
        }

        public IActionResult EditFlight(int? id)
        {
            var data = db.Flights.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditFlight(Flight flight)
        {
            db.Flights.Update(flight);
            db.SaveChanges();
            return RedirectToAction("VewFlights");
        }

        public IActionResult DeleteFlight(int? id)
        {
            var data = db.Flights.Find(id);
            db.Flights.Remove(data);
            db.SaveChanges();
            return RedirectToAction("VewFlights");
        }

        // Class Section
        public IActionResult AddClass()
        {
            return View();
        }
    }
}
