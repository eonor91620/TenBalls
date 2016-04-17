using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using SitePerso.DataBase;

namespace SitePerso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ConnexionModel connexion)
        {

            HomeModel model = new HomeModel();
            model.connexion = connexion;

            string path = "C:\\Users\\Thomas\\Documents\\Visual Studio 2015\\Projects\\SitePerso\\SitePerso\\Content\\Audio";

            model.listEnregistrement = ComposModel.getNomCompos(path);

            if (SitePerso.Helper.SessionHelper.getConnect() == false)
            {
                model.connexion.IsConnected = false;
            }
            model.connexion.IsConnected =  SitePerso.Helper.SessionHelper.getConnect();
            if (SitePerso.Helper.SessionHelper.getConnect() == true)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

             /*  PROCHAIN EVENEMENT  */
            using (TenBalls bdd = new TenBalls())
            {
                var dernierEvnt = (from e in bdd.evenementtenballs
                                   where e.date > DateTime.Now
                                   orderby e.date ascending
                                   select new { e.date.Day, e.date.Month, e.date.Year, e.nom}).FirstOrDefault();

                model.nomEvenement = dernierEvnt.nom;
                model.dateEvenement = dernierEvnt.Day + " " + SitePerso.Helper.DateHelper.GetMois(dernierEvnt.Month) + " " + dernierEvnt.Year;

            }

            model.news = new News();
            using (TenBalls bdd = new TenBalls())
            {
                var news = (from e in bdd.newstenballs
                            select e).FirstOrDefault();

                model.news.texte = news.text;
                model.news.date = news.date;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult modifNews(News Nouvelnews)
        {
            HomeModel model = new HomeModel();

            model.news = new News();
            using (TenBalls bdd = new TenBalls())
            {
                var news = (from n in bdd.newstenballs
                            select n).FirstOrDefault();

                news.text = Nouvelnews.texte;
                news.date = DateTime.Now;

                bdd.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}