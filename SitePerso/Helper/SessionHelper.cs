using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Helper
{
    public class SessionHelper
    {
        public static void setConnect(bool val)
        {
            System.Web.HttpContext.Current.Session["connect"] = val;

        }

        public static bool getConnect()
        {
            return Convert.ToBoolean(System.Web.HttpContext.Current.Session["connect"]);
        }

        public static void setNomAdmin(string nom)
        {
            System.Web.HttpContext.Current.Session["nom"] = nom;
        }

        public static string getNomAdmin()
        {
            return System.Web.HttpContext.Current.Session["nom"].ToString();
        }
    }
}