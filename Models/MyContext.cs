using Microsoft.EntityFrameworkCore;
namespace VendingMachine.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Candy> Candies { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Wrapper> Wrappers { get; set; }
    }
}