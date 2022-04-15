using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new DesignTimeDbContextFactory().CreateDbContext(args);
            
            Console.WriteLine("Starting database migration");
            
            dbContext.Database.Migrate();
            
            /// dbContext.SeedUsers();
            /// dbContext.SeedRestOfData();
        }
    }
}