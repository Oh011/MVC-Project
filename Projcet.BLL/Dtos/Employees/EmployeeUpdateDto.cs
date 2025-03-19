
using Project.DAL.Entites.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Dtos.Employees
{
    public class EmployeeUpdateDto
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters.")]
        public string Name { get; set; } = null!;


        [Range(20, 35, ErrorMessage = "Age must be between 20 and 35")]
        public int? Age { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9\s,'-./#]+$", ErrorMessage = "Please enter a valid address.")]
        public string? Address { get; set; }


        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }


        [EmailAddress]
        public string? Email { get; set; }


        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }


        public Gender Gender { get; set; }



        [Display(Name = "Department")] //--> will be shown in html as select list

        // value will be the department id , text --> Department Name

        public int? DepartmentId { get; set; }


        public EmployeeType EmployeeType { get; set; } // stored as int



    }
}
