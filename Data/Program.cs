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
            SeedGroup(dbContext);
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

            var adminStaff1 = new User()
            {
                Role = Roles.Admin,
                Username = "adminStaff1",
                Password = "password1",
                UserProfile = new UserProfile()
                {
                    Age = 30,
                    Email = "adminStaff1@test.com",
                    Fullname = "AdminStaff1 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                AdminStaff = new AdminStaff() 
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("adminStaff1")) is null)
            {
                context.Users.Add(adminStaff1);
            }

            var adminStaff2 = new User()
            {
                Role = Roles.Admin,
                Username = "adminStaff2",
                Password = "password2",
                UserProfile = new UserProfile()
                {
                    Age = 32,
                    Email = "adminStaff2@test.com",
                    Fullname = "AdminStaff2 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                AdminStaff = new AdminStaff()
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("adminStaff2")) is null)
            {
                context.Users.Add(adminStaff2);
            }

            var teacher1 = new User()
            {
                Role = Roles.Teacher,
                Username = "teacher1",
                Password = "password3",
                UserProfile = new UserProfile()
                {
                    Age = 26,
                    Email = "teacher1@test.com",
                    Fullname = "Teacher1 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                Teacher = new Teacher()
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("teacher1")) is null)
            {
                context.Users.Add(teacher1);
            }

            var teacher2 = new User()
            {
                Role = Roles.Teacher,
                Username = "teacher2",
                Password = "password4",
                UserProfile = new UserProfile()
                {
                    Age = 27,
                    Email = "teacher2@test.com",
                    Fullname = "Teacher2 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                Teacher = new Teacher()
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("teacher2")) is null)
            {
                context.Users.Add(teacher2);
            }

            var student1 = new User()
            {
                Role = Roles.Student,
                Username = "student1",
                Password = "password5",
                UserProfile = new UserProfile()
                {
                    Age = 19,
                    Email = "student1@test.com",
                    Fullname = "Student1 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                Student = new Student()
                {
                    GroupId = 1,
                    SpecializationId = 1
                }
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("student1")) is null)
            {
                context.Users.Add(student1);
            }

            var student2 = new User()
            {
                Role = Roles.Student,
                Username = "student2",
                Password = "password6",
                UserProfile = new UserProfile()
                {
                    Age = 19,
                    Email = "student2@test.com",
                    Fullname = "Student2 fullname",
                    ProfileImageUrl = "https://www.inkspired.ro/media/catalog/product/cache/1/image/500x500/3de37283ddf23e1390f09983ed9630a3/S/c/Scooby_Doo_artwork_.png"
                },
                Student = new Student()
                {
                    GroupId = 2,
                    SpecializationId = 1
                }
            };

            if (context.Users.FirstOrDefault(x => x.Username.Equals("student2")) is null)
            {
                context.Users.Add(student2);
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

        public static void SeedGroup(UMSDatabaseContext context)
        {
            var group = new Group()
            {
                Name = "Group1"
            };

            if (context.Groups.FirstOrDefault(x => x.Name.Equals("Group1")) is null)
            {
                context.Groups.Add(group);
            };

            group = new Group()
            {
                Name = "Group2"
            };

            if (context.Groups.FirstOrDefault(x => x.Name.Equals("Group2")) is null)
            {
                context.Groups.Add(group);
            };

            group = new Group()
            {
                Name = "Group3"
            };

            if (context.Groups.FirstOrDefault(x => x.Name.Equals("Group3")) is null)
            {
                context.Groups.Add(group);
            };

            context.SaveChanges();
        }
    }
}