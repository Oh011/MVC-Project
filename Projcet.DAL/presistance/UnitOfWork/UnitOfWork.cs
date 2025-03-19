using Project.DAL.prestance.Data;
using Project.DAL.prestance.Repostories.Departments;
using Project.DAL.prestance.Repostories.Employees;

namespace Project.DAL.presistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly ApplicationDbContext _Context;



        public UnitOfWork(ApplicationDbContext context)
        {
            _Context = context;

        }

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_Context);

        public IEmployeeRepository EmployeeRepository
        {
            get
            {


                return new EmployeeRepository(_Context);
            }
        }

        public int Complete()
        {


            return _Context.SaveChanges();


        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
