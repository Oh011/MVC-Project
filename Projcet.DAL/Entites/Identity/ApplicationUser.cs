using Microsoft.AspNetCore.Identity;

namespace Projcet.DAL.Entites.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string FName { get; set; }

        public string LName { get; set; }

        public bool IsAgree { get; set; }
    }
}
