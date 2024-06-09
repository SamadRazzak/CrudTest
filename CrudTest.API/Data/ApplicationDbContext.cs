using CrudTest.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "6d4746fc-9177-42fb-a7e4-63c294d1eddd", Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "1" },
                new IdentityRole { Id = "a06d1d9a-abf8-403a-8b1c-17e83444d465", Name = "Manager", NormalizedName = "Manager", ConcurrencyStamp = "2" },
                new IdentityRole { Id = "ca3abce8-ffd7-4d25-964c-c8e93de036d7", Name = "Moderator", NormalizedName = "Moderator", ConcurrencyStamp = "3" });
        }
    }
}
