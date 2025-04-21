using ARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.msg = "city inserted";
            return View();
        }
        public IActionResult ViewCities()
        {
            var list = db.Cities.ToList();
            return View(list);
        }
        public IActionResult EditCity(int? cityid)
        {
            var data = db.Cities.Find(cityid);
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
        public IActionResult DeleteCity(int? cityid)
        {
            var data = db.Cities.Find(cityid);
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
            ViewBag.msg = "Inserted";
            return View();
        }
    }
}
