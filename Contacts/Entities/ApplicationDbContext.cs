using Contacts.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);


            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.SeedCategories();
        }
    }
}
