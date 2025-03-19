using AutoMapper;
using Project.BLL.Dtos.Employees;
using Project.DAL.Entites.Employees;
using Project.DAL.presistance.UnitOfWork;

namespace Project.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {


        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;





        public EmployeeService(IUnitOfWork UnitOfWork, IMapper mapper)
        {

            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }
        public int CreateEmployee(CreateEmployeeDto Entity)
        {

            var employee = _mapper.Map<Employee>(Entity);




            //  Set additional properties if needed
            employee.LastModifiedBy = 1;
            employee.CreatedBy = 1;





            _UnitOfWork.EmployeeRepository.Add(employee);

            return _UnitOfWork.Complete();

        }

        public bool DeleteEmployee(int id)
        {


            var result = _UnitOfWork.EmployeeRepository.GetById(id);


            if (result != null)
            {
                _UnitOfWork.EmployeeRepository.Delete(result);
                int RowsAffected = _UnitOfWork.Complete();

                return RowsAffected > 0;
            }

            return false;
        }

        public IEnumerable<ReturnEmployeeDto> GetAllEmployees()
        {

            var result = _UnitOfWork.EmployeeRepository.GetAllQueryable().Where(e => e.IsDeleted == false).Select(E => new ReturnEmployeeDto
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Salary = E.Salary,
                IsActive = E.IsActive,
                Email = E.Email,
                Gender = E.Gender.ToString(),
                EmployeeType = E.EmployeeType.ToString(),
                Department = E.Department.Name //lazy loading


            });
            return result;
        }

        public ReturnEmployeeDetailsDto? GetEmployeeById(int id)
        {


            var result = _UnitOfWork.EmployeeRepository.GetById(id);

            if (result != null)
            {

                var ReturnEmployee = _mapper.Map<ReturnEmployeeDetailsDto>(result); ;

                ReturnEmployee.Department = result.Department != null ? result.Department.Name : null;


                return ReturnEmployee;
            }

            return null;
        }



        public IEnumerable<ReturnEmployeeDto> SearchByName(string name)
        {
            var result = _UnitOfWork.EmployeeRepository.GetAllQueryable().Where(e => e.IsDeleted == false &&


             (string.IsNullOrEmpty(name) || e.Name.ToLower().Contains(name.ToLower()))

            ).Select(E => new ReturnEmployeeDto
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Salary = E.Salary,
                IsActive = E.IsActive,
                Email = E.Email,
                Gender = E.Gender.ToString(),
                EmployeeType = E.EmployeeType.ToString(),
                Department = E.Department.Name //lazy loading


            }).ToList();
            return result;
        }

        public int UpdateEmployee(EmployeeUpdateDto Entity)
        {


            var employee = _mapper.Map<Employee>(Entity);







            employee.LastModifiedBy = 1;
            employee.CreatedBy = 1;


            _UnitOfWork.EmployeeRepository.Update(employee);

            return _UnitOfWork.Complete();

        }

    }
}
