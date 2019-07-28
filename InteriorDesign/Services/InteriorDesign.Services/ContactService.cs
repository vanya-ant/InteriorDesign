namespace InteriorDesign.Services
{
    using System.Net.Mail;

    using InteriorDesign.Services.Contracts;

    public class ContactService : IContactService
    {
        public void SendMail(string mailBody, string email)
        {
            using (var message = new MailMessage(email, "vanyad@gmail.com"))
            {
                message.To.Add(new MailAddress("vanyad@gmail.com"));
                message.From = new MailAddress(email);
                message.Subject = "New E-Mail from my website";
                message.Body = mailBody;

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;

                    smtpClient.Send(message);
                }
            }
        }
    }
}
