using Projcet.DAL.Entites.Departments;

namespace Projcet.DAL.prestance.Repostories.Departments
{
    public interface IDepartmentRepository
    {



        IEnumerable<Department> GetAll(bool AsNoTracking = true);

        Department? GetById(int id);

        int AddDepartment(Department department);

        int UpdateDepartment(Department department);


        int DeleteDepartment(Department department);

        public IQueryable<Department> GetAllQueryable();
    }
}
