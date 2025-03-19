namespace Project.BLL.Dtos.Departments
{
    public class ReturnDepartmentDetailsDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }


        public string Code { get; set; } = null!;


        public DateOnly CreationDate { get; set; }



        public DateTime CreatedAt { get; set; }


        public int CreatedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }


        public int LastModifiedBy { get; set; }


    }
}
