using Contacts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Extensions
{
    public static class ModelBuilderExtensionsCategories
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Junior Developer"
                },
                new Category
                {
                    Id = 2,
                    Name = "Mid Developer"
                },
                new Category
                {
                    Id = 3,
                    Name = "Senior Developer"
                }
                );
        }
    }
}
