using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Models
{
    public class HomeModel
    {
        public ComposModel listEnregistrement { get; set; }
        public EvenementsModel evenement { get; set; }
        public ConnexionModel connexion { get; set; }
        public News news { get; set; }
        public string nomEvenement { get; set; }
        public string dateEvenement { get; set; }
    }

    public class News
    {
        public string texte { get; set; }
        public DateTime date { get; set; }
    }

}