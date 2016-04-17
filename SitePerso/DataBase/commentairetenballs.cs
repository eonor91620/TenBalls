namespace SitePerso.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tenballs.commentairetenballs")]
    public partial class commentairetenballs
    {
        [Key]
        public int idCommentaire { get; set; }

        [Required]
        [StringLength(50)]
        public string Titre { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        public int Etat { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

    }
}
