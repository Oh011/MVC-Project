
using Project.BLL.Dtos.Employees;

namespace Project.BLL.Services.Employees
{
    public interface IEmployeeService
    {

        public IEnumerable<ReturnEmployeeDto> GetAllEmployees();

        public ReturnEmployeeDetailsDto? GetEmployeeById(int id);


        public int CreateEmployee(CreateEmployeeDto employee);


        public int UpdateEmployee(EmployeeUpdateDto employee);

        bool DeleteEmployee(int id);



        public IEnumerable<ReturnEmployeeDto> SearchByName(string name);

    }
}

