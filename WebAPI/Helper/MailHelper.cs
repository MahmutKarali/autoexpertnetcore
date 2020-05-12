using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAPI.Helper
{
    public class MailHelper
    {
        public static async Task SendMail(string mail,string body)
        {
            try
            {
                var fromAddress = new MailAddress("otoexpertizrapor@gmail.com");
                var toAddress = new MailAddress(mail);
                string fromPassword = "469507474";
                string host = "smtp.gmail.com";
                int port = 587;
                string subject = "OTO EXPERTİZ RAPORU";

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = port;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                    MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                    };

                    await smtp.SendMailAsync(mailMessage);
                    smtp.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
