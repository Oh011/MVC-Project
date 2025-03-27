using Projcet.DAL.Entites.Identity;
using System.Net;
using System.Net.Mail;

namespace Projcet.BLL.Common.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(Email email)
        {



            using var Client = new SmtpClient("smtp.gmail.com", 587);



            Client.EnableSsl = true;




            Client.Credentials = new NetworkCredential("oh1149725@gmail.com", "vaijigkbdovotkgb");




            await Client.SendMailAsync("oh1149725@gmail.com", email.To, email.Subject, email.Body);





        }
    }
}
