using Project.DAL.Entites.Departments;
using Project.DAL.presistance.Repostories.Generic;
using Project.DAL.prestance.Data;

namespace Project.DAL.prestance.Repostories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {


        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {


        }
    }
}
