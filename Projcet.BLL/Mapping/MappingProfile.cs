using AutoMapper;
using Project.BLL.Dtos.Employees;
using Project.DAL.Entites.Employees;




namespace Demo.BLL.Mapping
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {

            CreateMap<Employee, ReturnEmployeeDetailsDto>();  //entity --> Dto

            CreateMap<CreateEmployeeDto, Employee>(); //Dto--> Entity

            CreateMap<EmployeeUpdateDto, Employee>();


            CreateMap<ReturnEmployeeDetailsDto, EmployeeUpdateDto>();


        }

    }
}