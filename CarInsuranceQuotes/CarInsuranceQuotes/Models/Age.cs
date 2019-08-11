using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuotes.Models
{
    public class Age
    {
        public int GetAge(DateTime dateOfBirth)
        {
            //This model ended up being unnecessary after I figured another way to get the age from dateOfBirth
            DateTime now = DateTime.Today;
            int age = now.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > now.AddYears(-age)) age--;
            //Console.WriteLine("Your age is " + age);
            //Console.ReadLine();
            return age;
        }
    }
}