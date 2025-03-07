using System.ComponentModel.DataAnnotations;

namespace Projcet.BLL.Dtos.Departments
{
    public class CreateDepartmentDto
    {


        [Required(ErrorMessage = "⚠️ Name is required!")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "⚠️ Code is required!")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "⚠️ Creation Date is required !")]
        public DateOnly CreationDate { get; set; }
    }
}
