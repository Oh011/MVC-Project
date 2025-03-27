namespace MVC_Project.ViewModels.Roles
{
    public class RolesViewModel
    {

        public string Id { get; set; }

        public string Name { get; set; }



        public List<UserRoleViewModel> Users { get; set; } = new List<UserRoleViewModel>();
        public RolesViewModel()
        {

            Id = Guid.NewGuid().ToString();
        }
    }
}
