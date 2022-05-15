using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using veritabaniCRUD2.Models;

namespace veritabaniCRUD2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<veritabaniCRUD2.Models.birTablo>? birTablo { get; set; }
    }
}