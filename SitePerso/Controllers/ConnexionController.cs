using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitePerso.Controllers
{
    public class ConnexionController : Controller
    {
        // GET: Connexion
        public ActionResult ConnexionSite(ConnexionModel connexion)
        {
            ConnexionModel model = new ConnexionModel();


            if (connexion.Id == "admin" && connexion.Password == "admin")
            {
                model.Id = "Bonjour Ten Balls";
                model.IsConnected = true;

                SitePerso.Helper.SessionHelper.setConnect(model.IsConnected);
                SitePerso.Helper.SessionHelper.setNomAdmin(model.Id);           
            }
            else
            {
                model.IsConnected = false;
                model.messageError = "Id ou mot de passe incorrect.";
            }


            return RedirectToAction("Index", "Home", model);
        }
    }
}