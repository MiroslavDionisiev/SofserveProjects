using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                   new Book
                   {
                       Id = 1,
                       Name = "Name1",
                       Author = "Author1",
                       Genre = Genres.Fiction,
                       Language = Languages.Bulgarian,
                       Description = "Description1",
                       Published = 2000,
                       FreeCopies = 1,
                       Copies = 4
                   }

                );
            IdentityRole admin = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            IdentityRole member = new IdentityRole
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            };

            modelBuilder.Entity<IdentityRole>().HasData(
                   admin, member
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@email.com",
                NormalizedUserName = "ADMIN@EMAIL.COM",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123Aa@"),
                SecurityStamp = string.Empty
            };

            modelBuilder.Entity<ApplicationUser>().HasData(
                user
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId = admin.Id,
                       UserId = user.Id
                   }
                );
        }
    }
}
