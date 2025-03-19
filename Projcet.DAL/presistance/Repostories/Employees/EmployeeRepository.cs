using Project.DAL.Entites.Employees;
using Project.DAL.presistance.Repostories.Generic;
using Project.DAL.prestance.Data;

namespace Project.DAL.prestance.Repostories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
