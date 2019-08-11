using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuotes.Models;
using CarInsuranceQuotes.ViewModels;

namespace CarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, 
            short carYear, string carMake, string carModel, bool? dUI, short speedingTickets, bool? coverageType, decimal? TotalCost)
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

                //ESTIMATING QUOTE FORMULA
                //Part 1: Age:
                //QuoteVm quoteVm = new QuoteVm(); //Don't need this as we're pulling these properties from the QuoteVariable model which 
                //we instantiated already above. 
                quote.TotalCost = 50; 
                quote.TotalCost += (dateOfBirth.AddYears(18) > DateTime.Today) ? 100 : 0;
                //Think this means if dob +18 years is greater than today's date (meaning 
                //person is under 18) then add 100 to TotalCost. If it is greater than 18, add 0....Adding 0 is a problem though I think
                //as it conflicts with the next line
                quote.TotalCost += (dateOfBirth.AddYears(18) <= DateTime.Today && dateOfBirth.AddYears(25) > DateTime.Today) ? 25 : 0; // do I want && here or ||??
                quote.TotalCost += (dateOfBirth.AddYears(100) < DateTime.Today) ? 25 : 0;

                //Part 2: CarYear:
                quote.TotalCost += (carYear < 2000 || carYear > 2015) ? 25 : 0;

                //Part 3: CarMake & CarModel: 
                //quote.TotalCost += carMake.Equals("Porsche") ? 25 : 0;
                //quote.TotalCost += (carMake.Equals("Porsche") && carModel.Equals("911 Carrera")) ? 50 : 0;
                //Going to rewrite part 3 as an if statement as when I enter Porsche 911 Carrera it's coming out to 75$ when it should be just $50
                if (carMake.Equals("Porsche")) quote.TotalCost += 25;
                else if (carMake.Equals("Porshe") && carModel.Equals("911 Carrera")) quote.TotalCost += 50;
                else quote.TotalCost += 0;
                //It's working!! 

                //Part 4: Speeding Tickets
                quote.TotalCost += speedingTickets * 10;

                //Part 5: DUIs 
                quote.TotalCost += (dUI == true) ? (1.25m * quote.TotalCost) - quote.TotalCost : 0; 

                //Part 6: Coverage Type
                quote.TotalCost += (coverageType == true) ? (1.5m * quote.TotalCost) - quote.TotalCost : 0;

                //Part 7: Convert TotalCost to a currency value //Not going to bother with this 
                //as I would have to add money to my model and therefore my database, and I don't want to do that
                //string money = quote.TotalCost.ToString("C", CultureInfo.CurrentCulture); 
                //string Money = String.Format("{0:C}", TotalCost);

                db.QuoteVariables.Add(quote);
                db.SaveChanges();
                ViewBag.Message = quote;
            }
             
            return View("Price"); 
        }

        public ActionResult Index()
        {
            return View();
        }

        
    }
}