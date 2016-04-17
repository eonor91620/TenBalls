using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitePerso.Models
{
    public class ConnexionModel
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public bool IsConnected { get; set; }
        public string messageError { get; set; }
    }
}