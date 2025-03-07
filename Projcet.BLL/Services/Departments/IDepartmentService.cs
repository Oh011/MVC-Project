using Projcet.BLL.Dtos.Departments;

namespace Projcet.BLL.Services.Departments
{
    public interface IDepartmentService
    {


        public IEnumerable<ReturnDepartmentDto> GetAllDepartments();

        public ReturnDepartmentDetailsDto? GetById(int id);


        public int CreateDepartment(CreateDepartmentDto department);


        public int UpdateDepartment(UpdateDepartmentDto department);

        bool DeleteDepartment(int id);



    }
}
