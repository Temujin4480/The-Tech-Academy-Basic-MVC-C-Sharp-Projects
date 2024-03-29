﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuotes.ViewModels
{
    public class QuoteVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool? DUI { get; set; }
        public short SpeedingTickets { get; set; }
        public bool? CoverageType { get; set; }
        public decimal? TotalCost { get; set; }
    }
}