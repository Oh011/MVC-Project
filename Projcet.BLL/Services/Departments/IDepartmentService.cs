using Project.BLL.Dtos.Departments;

namespace Project.BLL.Services.Departments
{
    public interface IDepartmentService
    {


        public IEnumerable<ReturnDepartmentDto> GetAllDepartments();

        public ReturnDepartmentDetailsDto? GetById(int id);


        public int CreateDepartment(CreateDepartmentDto department);


        public int UpdateDepartment(UpdateDepartmentDto department);

        bool DeleteDepartment(int id);


        IEnumerable<ReturnDepartmentDto> SearchByName(string Name);



    }
}
