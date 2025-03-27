using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Dtos.Employees
{
    public class ReturnEmployeeDto
    {

        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public int? Age { get; set; }



        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }



        [DataType(DataType.EmailAddress)] // --> to display it as email in html use @Html.displayfor()
        public string? Email { get; set; }

        public bool IsActive { get; set; }



        public string Gender { get; set; }




        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; } // stored as int


        public string? Department { get; set; }


        public string? ImageName { get; set; }


    }
}
