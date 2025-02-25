using Projcet.DAL.Entites.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projcet.DAL.prestance.Repostories.Departments
{
    internal interface IDepartmentRepository
    {



        IEnumerable<Department> GetAll(bool AsNoTracking=true);

        Department? GetById(int id);

        int AddDepartment(Department department);

        int UpdateDepartment(Department department);


        int DeleteDepartment(Department department);
    }
}
