using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuotes.Models;
using CarInsuranceQuotes.ViewModels; 

namespace CarInsuranceQuotes.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceQuoteEntities db = new CarInsuranceQuoteEntities())
            {
                var quotes = (from c in db.QuoteVariables
                             select c).ToList();
                var quoteVms = new List<QuoteVm>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();
                    quoteVm.Id = quote.Id;
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVm.CoverageType = quote.CoverageType;
                    quoteVm.TotalCost = quote.TotalCost; 
                    quoteVms.Add(quoteVm);
                }

                return View(quoteVms);
            }
        }
    }
}