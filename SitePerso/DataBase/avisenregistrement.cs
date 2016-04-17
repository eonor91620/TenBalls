namespace SitePerso.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tenballs.avisenregistrement")]
    public partial class avisenregistrement
    {
        [Key]
        public int idAvis { get; set; }

        public int Note { get; set; }

        [Required]
        [StringLength(50)]
        public string titreEnregistrement { get; set; }
    }
}
