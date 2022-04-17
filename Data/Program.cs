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
            SeedSpecialization(dbContext);
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

        public static void SeedSpecialization(UMSDatabaseContext context)
        {
            var specialization = new Specialization()
            {
                Name = "Informatică în limba română"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Informatică în limba română")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Informatică în limba engleză"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Informatică în limba engleză")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Informatică în limba germană"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Informatică în limba germană")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Informatică în limba maghiară"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Informatică în limba maghiară")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Matematică în limba română"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Matematică în limba română")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Matematică în limba engleză"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Matematică în limba engleză")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Matematică în limba germană"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Matematică în limba germană")) is null)
            {
                context.Specializations.Add(specialization);
            };

            specialization = new Specialization()
            {
                Name = "Matematică în limba română"
            };

            if (context.Specializations.FirstOrDefault(x => x.Name.Equals("Matematică în limba maghiară")) is null)
            {
                context.Specializations.Add(specialization);
            };

            context.SaveChanges();
        }
    }
}