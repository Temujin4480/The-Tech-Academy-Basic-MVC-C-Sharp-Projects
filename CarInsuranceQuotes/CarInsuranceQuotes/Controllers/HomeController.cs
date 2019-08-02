using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuotes.Models;

namespace CarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, 
            short carYear, string carMake, string carModel, bool? dUI, short speedingTickets, bool? coverageType)
        {
            using (CarInsuranceQuoteEntities db = new CarInsuranceQuoteEntities())
            {
                var quote = new QuoteVariable();
                quote.FirstName = firstName;
                quote.LastName = lastName;
                quote.EmailAddress = emailAddress;
                quote.DateOfBirth = dateOfBirth;
                quote.CarYear = carYear;
                quote.CarMake = carMake;
                quote.CarModel = carModel; 
                quote.DUI = dUI;
                quote.SpeedingTickets = speedingTickets;
                quote.CoverageType = coverageType;



                db.QuoteVariables.Add(quote);
                db.SaveChanges();
            }
            return View("Price"); 
        }

        public ActionResult Index()
        {
            return View();
        }

        
    }
}