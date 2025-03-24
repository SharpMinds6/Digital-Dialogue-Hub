using DigitalDialogueHub.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Postavljanje odnosa između korisnika i komentara (kaskadno brisanje za korisnike)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Brisanje komentara ako se korisnik obriše

            // Postavljanje odnosa između postova i komentara (restriktivno brisanje za postove)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict); // Ovdje onemogućavamo kaskadno brisanje za postove
        }
    }
}
