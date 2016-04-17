using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitePerso.Controllers
{
    public class DeconnexionController : Controller
    {
        // GET: Deconnexion
        public ActionResult Deconnexion()
        {

            SitePerso.Helper.SessionHelper.setConnect(false);

            return RedirectToAction("Index", "Home");
        }
    }
}