namespace SitePerso.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TenBalls : DbContext
    {
        public TenBalls()
            : base("name=TenBalls")
        {
        }

        public virtual DbSet<avisenregistrement> avisenregistrement { get; set; }
        public virtual DbSet<evenementtenballs> evenementtenballs { get; set; }
        public virtual DbSet<commentairetenballs> commentairetenballs { get; set; }
        public virtual DbSet<newstenballs> newstenballs { get; set; }
        public virtual DbSet<reponsecommentairetenballs> reponsecommentairetenballs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<avisenregistrement>()
                .Property(e => e.titreEnregistrement)
                .IsUnicode(false);

            modelBuilder.Entity<evenementtenballs>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<evenementtenballs>()
                .Property(e => e.commentaire)
                .IsUnicode(false);

            modelBuilder.Entity<commentairetenballs>()
                .Property(e => e.Titre)
                .IsUnicode(false);

            modelBuilder.Entity<commentairetenballs>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<commentairetenballs>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<commentairetenballs>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<commentairetenballs>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<newstenballs>()
            .Property(e => e.text)
            .IsUnicode(false);

            modelBuilder.Entity<reponsecommentairetenballs>()
                .Property(e => e.textReponse)
                .IsUnicode(false);
        }
    }
}
