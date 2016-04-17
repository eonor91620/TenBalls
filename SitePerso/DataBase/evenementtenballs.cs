namespace SitePerso.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tenballs.evenementtenballs")]
    public partial class evenementtenballs
    {
        [Key]
        public int idEnregistrements { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string commentaire { get; set; }
    }
}
