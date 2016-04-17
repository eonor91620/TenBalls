namespace SitePerso.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tenballs.newstenballs")]
    public partial class newstenballs
    {
        [Key]
        public int idNews { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(500)]
        public string text { get; set; }
    }
}
