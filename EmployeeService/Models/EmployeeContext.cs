using Microsoft.EntityFrameworkCore;
using EmployeeService.Models;

namespace EmployeeService.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> employeess { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=tcp:itcserver.database.windows.net,1433;Initial Catalog=employeeDB;Persist Security Info=False;User ID=siddharth;Password=Kmail@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {   @"server=.\sqlexpress;initial catalog=TransationDataBase;user id=sa;password=Pass@123;trustservercertificate=true"
        //base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Employee>().HasKey(c => c.Email);
        // modelBuilder.Entity<Employee>().HasAlternateKey(c => c.Phone);
        // }

    }
}
