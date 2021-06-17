using BitCrunch.Models;
using Microsoft.EntityFrameworkCore;


namespace BitCrunch
{ 
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}