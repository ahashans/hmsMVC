using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}