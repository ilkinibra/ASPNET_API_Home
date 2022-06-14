using AspNetApi_Intro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetApi_Intro.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
