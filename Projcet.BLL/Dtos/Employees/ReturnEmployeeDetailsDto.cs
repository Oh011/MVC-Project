namespace Project.BLL.Dtos.Employees
{
    public class ReturnEmployeeDetailsDto
    {

        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public int? Age { get; set; }


        public string? Address { get; set; }


        public decimal? Salary { get; set; }



        public string? PhoneNumber { get; set; }


        public DateOnly HiringDate { get; set; }


        public string EmployeeType { get; set; } // stored as int


        public string? Email { get; set; }

        public bool IsActive { get; set; }



        public string Gender { get; set; }

        public DateTime CreatedOn { get; set; } //inserted when in database


        public int CreatedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }


        public int LastModifiedBy { get; set; }


        public bool IsDeleted { get; set; }


        public string? Department { get; set; }



    }
}
