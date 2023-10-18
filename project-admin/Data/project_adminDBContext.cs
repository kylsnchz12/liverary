using Microsoft.EntityFrameworkCore;
using project_admin.Models.Domain;

namespace project_admin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}