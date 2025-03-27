using Projcet.DAL.Entites.Identity;

namespace Projcet.BLL.Common.Services
{
    public interface IEmailService
    {


        public Task SendEmail(Email email);
    }
}
