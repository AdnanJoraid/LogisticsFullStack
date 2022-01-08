using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Persistence
{
    public class DataContext : DbContext
    {

        public DbSet<InventoryItem> Items {get; set;}

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<InventoryTransaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }

}