using Projcet.DAL.Entites.Departments;
using Projcet.DAL.presistance.Repostories.Generic;
using Projcet.DAL.prestance.Data;

namespace Projcet.DAL.prestance.Repostories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {


        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {


        }
    }
}
