using Microsoft.EntityFrameworkCore;
using Projcet.DAL.Entites.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

    }
}
