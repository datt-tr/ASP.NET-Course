using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext: IdentityDbContext<AppUser>
    {
        public ApplicationDBContext (DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Stock> 
        Stocks {get; set; }
        public DbSet<Comment> Comments {get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);

         List<IdentityRole> roles = new List<IdentityRole>{
            new IdentityRole
            {
                Id = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "a1e5c8b2-bfd3-4c36-a3e4-8924d0b2f1ae"
            },
            new IdentityRole
            {
                Id = "User",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "9cf6f117-3f6a-4eb8-bb1a-6b6de2f0dc4c"
            }
         };
         builder.Entity<IdentityRole>().HasData(roles);
         
      }
    }
}