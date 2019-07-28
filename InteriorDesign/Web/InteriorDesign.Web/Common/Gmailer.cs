namespace InteriorDesign.Web.Common
{
    using System.Net;
    using System.Net.Mail;

    public class Gmailer
    {
        static Gmailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587;
            GmailSSL = true;
        }

        public static string GmailUsername { get; set; }

        public static string GmailPassword { get; set; }

        public static string GmailHost { get; set; }

        public static int GmailPort { get; set; }

        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsHtml { get; set; }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, this.ToEmail))
            {
                message.Subject = this.Subject;
                message.Body = this.Body;
                message.IsBodyHtml = this.IsHtml;
                smtp.Send(message);
            }
        }
    }
}
