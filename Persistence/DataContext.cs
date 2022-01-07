using Microsoft.EntityFrameworkCore; 


namespace LogisticsAPI.Persistence {
    public class DataContext : DbContext{
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }

}