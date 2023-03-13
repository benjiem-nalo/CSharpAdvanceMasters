using System.Net;
using System.Net.Mail;
using Assignment_04.Events;

namespace Assignment_04.Service
{
    public class MailService
    {
        public static void Send(object? sender, VideoEventArgs e)
        {
            var fromEmail = new MailAddress("benjie.manalo@softvision.com", "Benjie");
            var toEmail = new MailAddress("gjgceredon@gmail.com", "Proctor");
            //Note: This is a work email password. Please reach out to me if needed.
            const string fromPassword = "";
            const string subject = "Video Out";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = $"Email: {e.Year.Categorize()} video with title {e.Title} was rented."
            })
            {
                //smtp.Send(message);
                Console.WriteLine("Sending email...");
            }   

            Console.WriteLine($"Email sent to {toEmail} with email body [ {e.Year.Categorize()} video with title {e.Title} was rented. ]");
        }
    }
}

