using CafeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManagementSystemProject.DataFolder
{
    public class MVCOrderDbContext : DbContext
    {
        public MVCOrderDbContext(DbContextOptions<MVCOrderDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}