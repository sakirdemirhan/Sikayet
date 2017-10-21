namespace Sikayet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SikayetContext : DbContext
    {
        public SikayetContext()
            : base("name=SikayetContext")
        {
        }

        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Mahalle> Mahalles { get; set; }
        public virtual DbSet<Moderator> Moderators { get; set; }
        public virtual DbSet<Sikayet> Sikayets { get; set; }
        public virtual DbSet<SilinmisKullanici> SilinmisKullanicis { get; set; }
        public virtual DbSet<SilinmisSikayet> SilinmisSikayets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Sikayets)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mahalle>()
                .HasMany(e => e.Sikayets)
                .WithRequired(e => e.Mahalle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sikayet>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Sikayet>()
                .Property(e => e.Yorum)
                .IsUnicode(false);

            modelBuilder.Entity<SilinmisSikayet>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<SilinmisSikayet>()
                .Property(e => e.Yorum)
                .IsUnicode(false);
        }
    }
}
