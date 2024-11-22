using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG6212_POEPART3.Models;

namespace PROG6212_POEPART3.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // This is the data to create the applicationDbContext plus IdentityDbContext<IdentityUser> with that I can create only two parts between Lecturer and Claim
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Claim> Claims { get; set; }
    }
}
