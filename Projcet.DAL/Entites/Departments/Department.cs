using Project.DAL.Entites.Employees;

namespace Project.DAL.Entites.Departments
{
    public class Department : ModelBase
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }


        public string Code { get; set; } = null!;


        public DateOnly CreationDate { get; set; }



        virtual public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
