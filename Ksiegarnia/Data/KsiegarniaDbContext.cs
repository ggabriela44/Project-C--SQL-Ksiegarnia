using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data
{
    public class KsiegarniaDbContext : DbContext
    {
        public KsiegarniaDbContext(DbContextOptions<KsiegarniaDbContext> options) : base(options) { }

        public DbSet<Ksiegarnia.Models.Dostawa> Dostawa { get; set; }
        public DbSet<Ksiegarnia.Models.Gatunek> Gatunek { get; set; }
        public DbSet<Ksiegarnia.Models.Klient> Klient { get; set; }
        public DbSet<Ksiegarnia.Models.Ksiazka> Ksiazka { get; set; }
        public DbSet<Ksiegarnia.Models.Zamowienie> Zamowienie { get; set; }
        public DbSet<Ksiegarnia.Models.KsiazkaZamowienie> KsiazkaZamowienie { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         
         
            modelBuilder.Entity<KsiazkaZamowienie>().HasKey(an => new
            {
                an.KsiazkaID,
                an.ZamowienieID
            }) ;
          
            modelBuilder.Entity<KsiazkaZamowienie>().HasOne(m => m.Ksiazka).WithMany(am => am.KsiazkiZamowione).HasForeignKey(m => m.KsiazkaID);
            modelBuilder.Entity<KsiazkaZamowienie>().HasOne(m => m.Zamowienie).WithMany(am => am.KsiazkaZamowione).HasForeignKey(m => m.ZamowienieID);

            base.OnModelCreating(modelBuilder); 
        }
          
        
    }
}
