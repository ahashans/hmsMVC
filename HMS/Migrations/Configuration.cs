using System;
using System.Data.Entity.Migrations;
using System.Linq;
using HMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<HMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HMS.Models.ApplicationDbContext context)
        {
            context.Departments.AddOrUpdate(
                d => d.Name,
                new Department
                {
                    Name = "Emergency Care",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-131071"
                },
                new Department
                {
                    Name = "Cardiology",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-12625"
                },
                new Department
                {
                    Name = "ENT",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-105385"
                },
                new Department
                {
                    Name = "Eye Care",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-131019"
                },
                new Department
                {
                    Name = "Diabetes Care",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-131019"
                },
                new Department
                {
                    Name = "Orthopedics",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-105402"
                }
                ,
                new Department
                {
                    Name = "Pulmology",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-45987"
                },
                new Department
                {
                    Name = "Child Care",
                    Fee = 500,
                    ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    IconCode = "ambulance-icon flaticon-icon-49091"
                }
            );
            context.SaveChanges();

            context.Events.AddOrUpdate(
                e => e.Title,
                new ProbableEvent
                {
                    Title= "Free checkup in children day",
                    EventDate = DateTime.Parse("2018-11-14"),
                    ShortDescription = 
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    FeatureImagePath= "~/Images/event-1.jpg"
                },
                new ProbableEvent
                {
                    Title = "Free checkup in victory day",
                    EventDate = DateTime.Parse("2018-12-16"),
                    ShortDescription =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    FeatureImagePath = "~/Images/event-2.jpg"
                }
            );
            context.SaveChanges();
            context.Blogs.AddOrUpdate(
                e => e.Title,
                new Blog
                {
                    Title = "Launched Child Care Department",                    
                    AuthorId = "2e0602e9-d083-42c4-b9ec-b86cf88d4656",
                    CreatedAt = DateTime.Today,
                    Content= 
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    FeatureImagePath = "~/Images/blog-img-4.jpg"
                },
                new Blog
                {
                    Title = "New machines in Eye Care",
                    AuthorId = "2e0602e9-d083-42c4-b9ec-b86cf88d4656",
                    CreatedAt = DateTime.Today,
                    Content =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    FeatureImagePath = "~/Images/blog-img-1.jpg"
                }
            );
            context.SaveChanges();

            context.Testimonials.AddOrUpdate(
                t => t.Name,
                new Testimonial
                {
                    Name= "John Doe",
                    Designation = "Engineer",                    
                    Message = 
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    ProfileImagePath= "~/Images/test-client-1.jpg"
                },
                new Testimonial
                {
                    Name = "Jane Doe",
                    Designation = "Reporter",
                    Message =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever.",
                    ProfileImagePath = "~/Images/test-client-2.jpg"
                }
            );

            //Seeding Doctor Users
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!(context.Users.Any(u => u.UserName == "doctor11@hms.com")))
            {                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor11@hms.com",
                    FullName = "John Doe",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Mobile = "01300111222",
                    Email = "doctor11@hms.com",
                    
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };                
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Emergency Care");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor21@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor21@hms.com",
                    FullName = "John Doe",
                    Mobile = "01300111222",
                    Email = "doctor21@hms.com",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Cardiology");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            
            if (!(context.Users.Any(u => u.UserName == "doctor31@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor31@hms.com",
                    FullName = "John Doe",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Mobile = "01300111222",
                    Email = "doctor31@hms.com",

                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "ENT");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor41@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor41@hms.com",
                    FullName = "John Doe",
                    Mobile = "01300111222",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Email = "doctor41@hms.com",
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Eye Care");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor51@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor51@hms.com",
                    FullName = "John Doe",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Mobile = "01300111222",
                    Email = "doctor51@hms.com",
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Diabetes Care");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor61@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor61@hms.com",
                    FullName = "John Doe",
                    Mobile = "01300111222",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Email = "doctor61@hms.com",
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Orthopedics");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor71@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor71@hms.com",
                    FullName = "John Doe",
                    Mobile = "01300111222",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Email = "doctor71@hms.com",
                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Pulmology");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            if (!(context.Users.Any(u => u.UserName == "doctor81@hms.com")))
            {
                
                var userToInsert = new ApplicationUser
                {
                    UserName = "doctor81@hms.com",
                    FullName = "John Doe",
                    Mobile = "01300111222",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    Address = "sample address",
                    Email = "doctor81@hms.com",

                    ProfileImagePath = "~/Images/dr-grid-1.jpg"
                };
                var result = userManager.Create(userToInsert, "Password@123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userToInsert.Id, "Doctor");
                    var department = context.Departments.SingleOrDefault(d => d.Name == "Child Care");
                    var doctorDepartment = new DoctorDepartment
                    {
                        DepartmentId = department.DepartmentId,
                        DoctorUserId = userToInsert.Id
                    };
                    context.DoctorDepartments.AddOrUpdate(doctorDepartment);
                    context.SaveChanges();
                }
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
