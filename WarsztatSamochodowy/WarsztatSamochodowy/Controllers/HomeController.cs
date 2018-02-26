using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarsztatSamochodowy.Context;
using WarsztatSamochodowy.Models;
using System.Data.Entity;

namespace WarsztatSamochodowy.Controllers
{
    public class HomeController : Controller
    {
        private WarsztatSamochodowyDbContext db = new WarsztatSamochodowyDbContext();

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

            var carDetails = db.car.FirstOrDefault(x => x.CarId == searchCar.CarId && x.RegisterNumber == searchCar.RegisterNumber);

            if (carDetails == null)
            {
                searchCar.CarErrorMessage = "W naszym warsztacie nie ma takiego samochodu.";

                return View("CheckYourCar", searchCar);
            }
            else
            {
                return View("CarFound", carDetails);
            }

        }
        public ActionResult CarFound()
        {

            return View();
        }
    }
}