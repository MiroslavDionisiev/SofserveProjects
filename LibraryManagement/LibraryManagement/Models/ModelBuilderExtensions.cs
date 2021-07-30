using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId = admin.Id,
                       UserId = "a93e1c24-46c2-4219-ae74-9c0dc009316e"
                   }
                );
        }
    }
}
