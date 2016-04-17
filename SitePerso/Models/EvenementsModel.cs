using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Models
{
    public class EvenementsModel
    {
        public string Nom { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public List<ListEvenement> listEvenement { get; set; }
        public ConnexionModel connexion { get; set; }
        public bool IsUpload { get; set; }
        public List<Commentaire> listCommentaire { get; set; }
        public List<ReponseCommentaire> listReponseCommentaire { get; set; }
    }

    public class ListEvenement
    {
        public string Nom { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
    }
}