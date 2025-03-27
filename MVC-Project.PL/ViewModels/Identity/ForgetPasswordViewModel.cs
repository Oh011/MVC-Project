using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels.Identity
{
    public class ForgetPasswordViewModel
    {

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
