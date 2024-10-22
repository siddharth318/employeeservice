
using TaskManagementAPI.Models;
//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI.Models
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext() { }
        public DbSet<TaskManagement> trans { get; set; }
        // public DbSet<Dish> food { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=tcp:sidservers.database.windows.net,1433;Initial Catalog=employee-db;Persist Security Info=False;User ID=siddharth;Password=Kmail@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
