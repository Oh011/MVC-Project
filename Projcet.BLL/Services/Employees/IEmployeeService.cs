
using Project.BLL.Dtos.Employees;

namespace Project.BLL.Services.Employees
{
    public interface IEmployeeService
    {

        public IEnumerable<ReturnEmployeeDto> GetAllEmployees();

        public ReturnEmployeeDetailsDto? GetEmployeeById(int id);


        public Task<int> CreateEmployee(CreateEmployeeDto employee);


        public Task<int> UpdateEmployee(EmployeeUpdateDto employee);

        bool DeleteEmployee(int id);


        public Task<bool> DeleteProfileImage(int Id);

        public IEnumerable<ReturnEmployeeDto> SearchByName(string name);

    }
}

