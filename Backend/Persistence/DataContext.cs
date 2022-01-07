using Microsoft.EntityFrameworkCore;


namespace Backend.Persistence
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }

}