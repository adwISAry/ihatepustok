using Humanizer;
using nov30task.ExternalServices.Interfaces;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace nov30task.ExternalServices.Implements
{
    public class EmailService: IEmailService
    {
        IConfiguration _configuration { get; }
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Send(string toMail, string header, string body, bool isHtml = true) 
        {
            SmtpClient smtpClient = new SmtpClient(_configuration["Email: Host"], Convert.ToInt32(_configuration["Email: Port"]));
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_configuration["Email : Username"], _configuration["Email : Password"]);


            MailAddress from = new MailAddress(_configuration["Email : Username"], "Pustok");
            MailAddress to = new MailAddress("toMail");


            MailMessage message = new MailMessage(from, to);
            message.Body = "Example";
            message.Subject = "Header";
            smtpClient.Send(message);
        }

    }
}
