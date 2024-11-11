using Microsoft.EntityFrameworkCore;

namespace apiassignment.Models{
    public class shopcontext : DbContext
    {
        public shopcontext(DbContextOptions<shopcontext> options) : base(options)
        {

        }

        public DbSet<order> Orders { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<user> Users { get; set; }

    }
}