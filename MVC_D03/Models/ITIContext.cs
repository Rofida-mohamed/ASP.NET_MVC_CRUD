using Microsoft.EntityFrameworkCore;

namespace MVC_D03.Models
{
    public class ITIContext :DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<users> Users { get; set; }

        public ITIContext() { }

        public ITIContext(DbContextOptions opations ) : base(opations) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1Q5AJ99;Database=Test3;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
