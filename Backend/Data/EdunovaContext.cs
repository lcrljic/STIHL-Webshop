using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Stavka> Stavke { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Racun>().HasOne(g => g.Kupac);

            modelBuilder.Entity<Stavka>().HasOne(g => g.Racun);
            modelBuilder.Entity<Stavka>().HasOne(g => g.Proizvod);
        }

    }
}
