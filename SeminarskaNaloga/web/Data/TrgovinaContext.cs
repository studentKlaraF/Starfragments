using SeminarskaNaloga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SeminarskaNaloga.Data
{
    public class TrgovinaContext : IdentityDbContext<AppUser>
    {
        public TrgovinaContext(DbContextOptions<TrgovinaContext> options) : base(options)
        {
        }

        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Narocilo> Narocilo { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Uporabnik> Uporabnik { get; set; }
        public DbSet<ZgodovinaNarocanja> ZgodovinaNarocanja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<Narocilo>().ToTable("Narocilo");
            modelBuilder.Entity<Racun>().ToTable("Racun");
            modelBuilder.Entity<Uporabnik>().ToTable("Uporabnik");
            modelBuilder.Entity<ZgodovinaNarocanja>().ToTable("ZgodovinaNarocanja");
        }
    }
}