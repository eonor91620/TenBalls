using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using SitePerso.DataBase;

namespace SitePerso.Controllers
{
    public class ComposController : Controller
    {
        public ActionResult Index()
        {
            string path = Server.MapPath("Content\\Audio\\").Replace("\\Compos", "");
            ComposModel model = ComposModel.getNomCompos(path);

            model.connexion = new ConnexionModel();


            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

            using (TenBalls bdd = new TenBalls())
            {
                var commentaire = (from c in bdd.commentairetenballs
                                   where c.Etat == 1
                                   && c.type == "compos"
                                   select c).ToList();


                var reponse = (from r in bdd.reponsecommentairetenballs
                               where r.etat == 1
                               select r).ToList();

                model.listReponseCommentaire = new List<ReponseCommentaire>();
                if (commentaire.Count() > 0)
                {
                    model.listCommentaire = new List<Commentaire>();
                    foreach (var item in commentaire)
                    {
                        Commentaire com = new Commentaire
                        {
                            id = item.idCommentaire,
                            Titre = item.Titre,
                            Nom = item.nom,
                            Date = item.Date,
                            Texte = item.Text,
                            type = item.type
                        };

                        model.listCommentaire.Add(com);

                    }
                }

                if (reponse.Count() > 0)
                {

                    foreach (var rep in reponse)
                    {
                        ReponseCommentaire resp = new ReponseCommentaire
                        {
                            idReponse = rep.idReponse,
                            date = rep.dateReponse,
                            texte = rep.textReponse,
                            idCommentaire = rep.idCommentaire
                        };

                        model.listReponseCommentaire.Add(resp);
                    }
                }

            }


            return View(model);
        }
        
        public ActionResult NewCompos()
        {
            ComposModel model = new ComposModel();
            model.IsUpload = false;

            model.connexion = new ConnexionModel();

            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            } 

            return View(model);
        }

        [HttpPost]
        public ActionResult NewCompos(ComposModel compos, FormCollection f)
        {
            ComposModel model = new ComposModel();

            model.connexion = new ConnexionModel();

            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

            HttpPostedFileWrapper File1 = compos.Chemin;
            
            if ((File1 != null) && (File1.ContentLength > 0))
            {
                string date = DateTime.Now.ToString("dd-MM-yyy-HH_mm");
                string fn = date + "-" + compos.Titre + ".mp3";
                string SaveLocation = Server.MapPath("Content\\Audio\\").Replace("\\Compos", "") + fn;
                try
                {
                    File1.SaveAs(SaveLocation);

                    string message = "Bonjour, \n \n la musique " + compos.Titre + " a été uploadée sur le site. Vous pouvez désormais l'écouter, la supprimer ou la télécharger. \n \n Cordialement, \n \n Vos Balls.";
                    string sujet = "Nouvelle musique uploader sur le site.";

                    // Envoie de mail au groupe
                    //SitePerso.Helper.EmailHelpers.SendMail(sujet, message);
                    Response.Write("The file has been uploaded.");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }

                model.IsUpload = true;
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
            return View(model);
        }

        public ActionResult suppressionCompos(ComposModel compos, FormCollection f)
        {
            string file = f.Get(0);
            if (compos.IsDelete)
            {
                if (System.IO.File.Exists(@"C:\\Users\\Thomas\\Documents\\Visual Studio 2015\\Projects\\SitePerso\\SitePerso\\Content\\Audio\" + file))
                {
                    System.IO.File.Delete(@"C:\\Users\\Thomas\\Documents\\Visual Studio 2015\\Projects\\SitePerso\\SitePerso\\Content\\Audio\" + file);
                }
            }

            Thread.Sleep(5000);
                return RedirectToAction("Index", "Compos");
        }

        [HttpPost]
        public ActionResult NewCommentaire(Commentaire c)
        {

            try
            {
                using (TenBalls bdd = new TenBalls())
                {
                    var commentaire = new commentairetenballs
                    {
                        nom = c.Nom,
                        Titre = c.Titre,
                        Email = c.Email,
                        Date = DateTime.Now,
                        Text = c.Texte,
                        Etat = 0,
                        type = "compos"
                    };

                    bdd.commentairetenballs.Add(commentaire);
                    bdd.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }



            return RedirectToAction("Index", "Compos");
        }

        [HttpPost]
        public ActionResult newReponse(ReponseCommentaire rep, int idCommentaire)
        {
            try
            {
                using (TenBalls bdd = new TenBalls())
                {
                    var reponse = new reponsecommentairetenballs
                    {
                        dateReponse = DateTime.Now,
                        textReponse = rep.texte,
                        idCommentaire = idCommentaire,
                        etat = 1
                    };

                    bdd.reponsecommentairetenballs.Add(reponse);
                    bdd.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Index", "Compos");
        }
    }


}