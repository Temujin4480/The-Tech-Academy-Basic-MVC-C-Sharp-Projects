using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuotes
{
    public class QuoteProperties
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public Nullable<bool> DUI { get; set; }
        public Nullable<int> SpeedingTickets { get; set; }
        public Nullable<bool> Coverage { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}