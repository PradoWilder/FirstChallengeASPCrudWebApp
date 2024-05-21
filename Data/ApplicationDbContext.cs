using Microsoft.EntityFrameworkCore;
using FirstChallengeCRUDWebApp.Models;
using System.Collections.Generic;

namespace FirstChallengeCRUDWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
