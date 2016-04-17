using SitePerso.DataBase;
using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SitePerso.Controllers
{
    public class CommentaireController : Controller
    {

        public ActionResult Index()
        {
            Commentaire model = new Commentaire();

            model.connexion = new ConnexionModel();


            model.connexion.IsConnected = SitePerso.Helper.SessionHelper.getConnect();
            if (model.connexion.IsConnected)
            {
                model.connexion.Id = SitePerso.Helper.SessionHelper.getNomAdmin();
            }


            using (TenBalls bdd = new TenBalls())
            {
                var commentaireEnAttente = (from c in bdd.commentairetenballs
                                   where c.Etat == 0
                                   select c);

                var commentaireValider = (from c in bdd.commentairetenballs
                                            where c.Etat == 1
                                            select c);

                var commentairesupprimer = (from c in bdd.commentairetenballs
                                            where c.Etat == -1
                                            select c);

                // en attente
                if (commentaireEnAttente.Count() > 0)
                {
                    model.listCommentaireEnAttente = new List<Commentaire>();
                    foreach (var item in commentaireEnAttente)
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

                        model.listCommentaireEnAttente.Add(com);
                    }
                }

                // valider
                if (commentaireValider.Count() > 0)
                {
                    model.listCommentaireValider = new List<Commentaire>();
                    foreach (var item in commentaireValider)
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

                        model.listCommentaireValider.Add(com);
                    }
                }

                // Supprimer
                if (commentairesupprimer.Count() > 0)
                {
                    model.listCommentaireSupprimer = new List<Commentaire>();
                    foreach (var item in commentairesupprimer)
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

                        model.listCommentaireSupprimer.Add(com);
                    }
                }

            }


            return View(model);
        }


        public ActionResult ValiderCommentaire(int id)
        {

            using (TenBalls bdd = new TenBalls())
            {

                var com = (from c in bdd.commentairetenballs
                           where c.idCommentaire == id
                           select c).FirstOrDefault();

                com.Etat = 1;
                bdd.SaveChanges();


                string message = "Bonjour, \n \n votre commentaire : >" + com.Text + " ajouté le " + com.Date + "</b> a été validé et est maintenant visible sur le site sur la page des enregistrements. \n \n Cordialement, \n \n Vos Balls.";
                string typeCommentaire = com.type == "compos" ? "la musique" : "l'évènement ";
                string sujet = "Votre commentaire sur " + typeCommentaire + com.Titre + " a bien été validé sur le site.";

                // Envoie de mail au client
                SitePerso.Helper.EmailHelpers.SendMail(sujet, message, com.Email);
            }

            return RedirectToAction("Index", "Commentaire");
        }

        public ActionResult SupprimerCommentaire(int id)
        {

            using (TenBalls bdd = new TenBalls())
            {
                var com = (from c in bdd.commentairetenballs
                           where c.idCommentaire == id
                           select c).FirstOrDefault();

                com.Etat = -1;

                bdd.SaveChanges();
            }

            return RedirectToAction("Index", "Commentaire");
        }

        public ActionResult SupprimerReponse(int id, string univers)
        {

            using (TenBalls bdd = new TenBalls())
            {
                var rep = (from r in bdd.reponsecommentairetenballs
                           where r.idReponse == id
                           select r).FirstOrDefault();

                rep.etat = -1;

                bdd.SaveChanges();
            }

            if (univers == "compos")
            {
                return RedirectToAction("Index", "Compos");
            }
            else
            {
                return RedirectToAction("Index", "Evenements");
            }

        }

        public ActionResult ModifierReponse(ReponseCommentaire rep, int id, string univers)
        {
            using (TenBalls bdd = new TenBalls())
            {
                var resp = (from res in bdd.reponsecommentairetenballs
                            where res.idReponse == id
                            select res).FirstOrDefault();

                resp.textReponse = rep.texte;
                resp.dateReponse = DateTime.Now;

                bdd.SaveChanges();
            }

            if (univers =="compos")
            {
                return RedirectToAction("Index", "Compos");
            }
            else
            {
                return RedirectToAction("Index", "Evenements");
            }

        }
    }
}