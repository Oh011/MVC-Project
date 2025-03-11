using Microsoft.EntityFrameworkCore;
using Projcet.DAL.Entites.Departments;
using Projcet.DAL.Entites.Employees;
using System.Reflection;

namespace Projcet.DAL.prestance.Data
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
