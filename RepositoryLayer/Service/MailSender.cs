using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Service
{
    public class MailSender
    {
        public void SendMail(string data, string email)
        {
            try
            {
                string FROMNAME = "Sandhya Patil", FROM = "sandhyapatil364@gmail.com", TO = email, SUBJECT = "Registration Details";
                int PORT = 587;
                string message = data;
                var BODY = "Hi," + message;

                MailMessage mailMessage = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com", PORT);
                mailMessage.From = new MailAddress(FROM, FROMNAME);
                mailMessage.To.Add(new MailAddress(TO));
                mailMessage.Subject = SUBJECT;
                mailMessage.Body = BODY;

                client.Credentials = new NetworkCredential(FROM, "Sandhya@1995");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
