using Project.DAL.prestance.Repostories.Departments;
using Project.DAL.prestance.Repostories.Employees;

namespace Project.DAL.presistance.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {




        public IDepartmentRepository DepartmentRepository { get; }

        public IEmployeeRepository EmployeeRepository { get; }



        public int Complete();



    }
}
