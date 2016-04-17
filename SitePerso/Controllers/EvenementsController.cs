using SitePerso.DataBase;
using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitePerso.Controllers
{
    public class EvenementsController : Controller
    {
        // GET: Evenements
        public ActionResult Index()
        {

            EvenementsModel model = new EvenementsModel();

            model.connexion = new ConnexionModel();

            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

            List<string> listEvnt = new List<string>();
            using (TenBalls bdd = new TenBalls())
            {
                var evnt = (from e in bdd.evenementtenballs
                            where e.date > DateTime.Now
                            select e);
                model.listEvenement = new List<ListEvenement>();
                foreach (var item in evnt)
                {
                    ListEvenement e = new ListEvenement
                    {
                        Nom = item.nom,
                        Date = item.date,
                        Detail = item.commentaire
                    };

                    model.listEvenement.Add(e);
                }


                var commentaire = (from c in bdd.commentairetenballs
                                   where c.Etat == 1
                                   && c.type == "event"
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

        public ActionResult NewEvenements()
        {

            EvenementsModel model = new EvenementsModel();
            model.connexion = new ConnexionModel();

            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

            model.IsUpload = false;

            return View(model);
        }


        [HttpPost]
        public ActionResult NewEvenements(EvenementsModel evenement)
        {

            EvenementsModel model = new EvenementsModel();
            model.connexion = new ConnexionModel();

            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }

            try
            {
                using (TenBalls bdd = new TenBalls())
                {
                    var evenment = new evenementtenballs
                    {
                        nom = evenement.Nom,
                        date = evenement.Date,
                        commentaire = evenement.Detail
                    };

                    bdd.evenementtenballs.Add(evenment);
                    bdd.SaveChanges();
                }

                model.IsUpload = true;
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewCommentaire(Commentaire c)
        {

            try
            {
                using (TenBalls bdd = new TenBalls())
                {
                    var evenement = new commentairetenballs
                    {
                        nom = c.Nom,
                        Titre = c.Titre,
                        Email = c.Email,
                        Date = DateTime.Now,
                        Text = c.Texte,
                        Etat = 0,
                        type = "event"
                    };

                    bdd.commentairetenballs.Add(evenement);
                    bdd.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }



            return RedirectToAction("Index", "Evenements");
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


            return RedirectToAction("Index", "Evenements");
        }
    }
}