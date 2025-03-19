using Microsoft.EntityFrameworkCore;
using Project.DAL.Entites.Departments;
using Project.DAL.Entites.Employees;
using System.Reflection;

namespace Project.DAL.prestance.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{


        //    optionsBuilder.UseSqlServer("Server=.;DataBase=MVCProject;Integrated Security=true ; TrustServerCertificate=true");
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }






        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
