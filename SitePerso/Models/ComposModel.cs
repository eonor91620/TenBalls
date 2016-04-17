using SitePerso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace SitePerso.Models
{
    public class ComposModel
    {
        public string Titre { get; set; }
        public HttpPostedFileWrapper Chemin { get; set; }
        public List<string> listNomCompos { get; set; }
        public bool IsUpload { get; set; }
        public bool IsDelete { get; set; }
        public ConnexionModel connexion { get; set; }
        public List<Commentaire> listCommentaire { get; set; }
        public List<ReponseCommentaire> listReponseCommentaire { get; set; }


       public static ComposModel getNomCompos(string path)
        {

            ComposModel model = new ComposModel();

            model.listNomCompos = new List<string>();
            List<string> dirs = new List<string>(Directory.EnumerateFiles(path));

            foreach (var dir in dirs)
            {
                
                string nomFichier = dir.Split('\\').Last();
                //nomFichier = nomFichier.Split('.').First();
                model.listNomCompos.Add(nomFichier);
            }
            

            return model;
        }
    }
}