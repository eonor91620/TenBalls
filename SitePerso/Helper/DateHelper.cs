using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Helper
{
    public class DateHelper
    {
        public static string GetMois(int mois)
        {
            string Mois = string.Empty;
            if (mois == 1)
            {
                Mois = "January";
            }
            else if (mois == 2)
            {
                Mois = "February";
            }
            else if (mois == 3)
            {
                Mois = "March";
            }
            else if (mois == 4)
            {
                Mois = "April";
            }
            else if (mois == 5)
            {
                Mois = "May";
            }
            else if (mois == 6)
            {
                Mois = "June";
            }
            else if (mois == 7)
            {
                Mois = "July";
            }
            else if (mois == 8)
            {
                Mois = "August";
            }
            else if (mois == 9)
            {
                Mois = "September";
            }
            else if (mois == 10)
            {
                Mois = "October";
            }
            else if (mois == 11)
            {
                Mois = "November";
            }else
            {
                Mois = "December";
            }

            return Mois;
        }
    }
}