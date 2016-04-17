namespace SitePerso.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tenballs.reponsecommentairetenballs")]
    public partial class reponsecommentairetenballs
    {
        [Key]
        public int idReponse { get; set; }

        public DateTime dateReponse { get; set; }

        public int idCommentaire { get; set; }

        [Required]
        [StringLength(500)]
        public string textReponse { get; set; }

        public int etat { get; set; }
    }
}
