using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Models
{
    public class Commentaire
    {
        public int id { get; set; }
        public string Titre { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Texte { get; set; }
        public string type { get; set; }
        public ConnexionModel connexion { get; set; }
        public List<Commentaire> listCommentaireEnAttente { get; set; }
        public List<Commentaire> listCommentaireValider { get; set; }
        public List<Commentaire> listCommentaireSupprimer { get; set; }
        public List<ReponseCommentaire> listReponseCommentaire { get; set; }
    }

    public class ReponseCommentaire
    {
        public int idReponse { get; set; }
        public int idCommentaire { get; set; }
        public DateTime date { get; set; }
        public string texte { get; set; }
    }
}