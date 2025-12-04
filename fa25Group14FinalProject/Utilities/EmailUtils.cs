using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace fa25Group14FinalProject.Utilities
{
    public static class EmailUtils
    {
        // TODO: change these three values for YOUR team Gmail
        // Example: bevo.books.team14@gmail.com and its app password
        private const string SenderEmail = "bevo.books.team14@gmail.com";
        private const string SenderDisplayName = "Team 14";
        private const string SenderPassword = "etkf tiud qorl kalz";

        /// <summary>
        /// Sends a simple text email using the team Gmail account.
        /// </summary>
        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                return;

            using (var message = new MailMessage())
            {
                message.From = new MailAddress(SenderEmail, SenderDisplayName);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false; // keep it simple text for grading

                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);

                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
