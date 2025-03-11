using Projcet.DAL.Entites.Employees;
using Projcet.DAL.presistance.Repostories.Generic;
using Projcet.DAL.prestance.Data;

namespace Projcet.DAL.prestance.Repostories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
