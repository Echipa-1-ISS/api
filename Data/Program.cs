using Data.models;
using Data.Models;
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

            SeedUsers(dbContext);
        }

        public static void SeedUsers(UMSDatabaseContext context)
        {
            var student = new User()
            {
                Role = Roles.Student,
                Username = "student",
                Password = "password", // Bcrypt.hash("pasword")
                UserProfile = new UserProfile()
                {
                    Age = 15,
                    Email = "student@test.com",
                    Fullname = "Student fullname",
                    ProfileImageUrl =
                        "https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/2020-Chevrolet-Corvette-Stingray/0x0.jpg?fit=crop&format=jpg&crop=4560,2565,x790,y784,safe"
                }
            };
            
            if (context.Users.FirstOrDefault(x => x.Username.Equals("student")) is null)
            {
                context.Users.Add(student);    
            }

            // add teacher, add adminStaff
            context.SaveChanges();
        }
    }
}