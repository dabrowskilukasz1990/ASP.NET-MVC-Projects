using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WarsztatSamochodowy.Context;
using WarsztatSamochodowy.Models;

namespace WarsztatSamochodowy.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employeeModel)
        {
            using (WarsztatSamochodowyDbContext db = new WarsztatSamochodowyDbContext())
            {
                var employeeDetails = db.employee.Where(x => x.Login == employeeModel.Login && x.Password == employeeModel.Password).FirstOrDefault();

                if (employeeDetails == null)
                {
                    employeeModel.LoginErrorMessage = "Nieprawidłowy login lub hasło";

                    return View("Login", employeeModel);
                }
                else
                {
                    Session["EmployeeId"] = employeeDetails.EmployeeId;
                    Session["FirstName"] = employeeDetails.FirstName;


                    return RedirectToAction("Manage", "Account");
                }
            }
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            int employeeId = (int)Session["EmployeeId"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}