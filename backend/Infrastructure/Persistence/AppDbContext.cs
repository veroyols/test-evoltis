using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                //entity.ToTable("Contacts");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
