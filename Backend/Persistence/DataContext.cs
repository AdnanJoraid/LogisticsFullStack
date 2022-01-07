using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Persistence
{
    public class DataContext : DbContext
    {

        public DbSet<Item> Items {get; set;}

        public DbSet<Inventory> Inventory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }

}