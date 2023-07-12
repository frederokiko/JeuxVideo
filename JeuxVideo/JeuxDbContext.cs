
using ApiEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEF
{
    public class JeuxDbContext : DbContext
    {
        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jeu>()
                .HasOne(j => j.Genre)
                .WithMany()
                .HasForeignKey(j => j.GenreId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=GOS-VDI910\\TFTIC;Initial Catalog=JeuxVideo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }


}