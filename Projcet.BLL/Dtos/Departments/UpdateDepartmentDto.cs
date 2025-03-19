namespace Project.BLL.Dtos.Departments
{
    public class UpdateDepartmentDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }


        public string Code { get; set; } = null!;


        public DateOnly CreationDate { get; set; }
    }
}
