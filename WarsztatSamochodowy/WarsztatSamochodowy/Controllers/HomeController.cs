using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarsztatSamochodowy.Context;
using WarsztatSamochodowy.Models;

namespace WarsztatSamochodowy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckYourCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckYourCar(Car searchCar)
        {
            using (WarsztatSamochodowyDbContext db = new WarsztatSamochodowyDbContext())
            {
                var carDetails = db.car.FirstOrDefault(x => x.CarId == searchCar.CarId && x.RegisterNumber == searchCar.RegisterNumber);

                if (carDetails == null)
                {
                    searchCar.CarErrorMessage = "W naszym warsztacie nie ma takiego samochodu.";

                    return View("CheckYourCar", searchCar);
                }
                else
                {
                    return View("Test", carDetails);
                }
            }
        }
        public ActionResult Test()
        {
            
            return View();
        }
    }
}