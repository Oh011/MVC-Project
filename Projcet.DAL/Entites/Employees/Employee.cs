using Project.DAL.Entites.Common.Enums;
using Project.DAL.Entites.Departments;

namespace Project.DAL.Entites.Employees
{
    public class Employee : ModelBase
    {

        public string Name { get; set; } = null!;

        public int? Age { get; set; }


        public string? Address { get; set; }


        public decimal? Salary { get; set; }



        public string? Email { get; set; }

        public bool IsActive { get; set; }


        public string? PhoneNumber { get; set; }


        public DateOnly HiringDate { get; set; }


        public Gender Gender { get; set; }





        public EmployeeType EmployeeType { get; set; } // stored as int in Database


        virtual public Department? Department { get; set; }


        public int? DepartmentId { get; set; }


    }
}
