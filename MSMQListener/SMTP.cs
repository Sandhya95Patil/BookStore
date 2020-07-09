using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MSMQListener
{
    public class SMTP
    {
        public static bool SendMail(string data, string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email))
                {

                    string FROMNAME = "Sandhya", FROM = "sandhyapatil364@gmail.com", TO = email, SUBJECT = "Register";
                    int PORT = 587;
                    string message = "Your Registration Successfull";
                    var BODY = "Hello," + message;

                    MailMessage mailMessage = new MailMessage();
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", PORT);
                    mailMessage.From = new MailAddress(FROM, FROMNAME);
                    mailMessage.To.Add(new MailAddress(TO));
                    mailMessage.Subject = SUBJECT;
                    mailMessage.Body = BODY;

                    client.Credentials = new NetworkCredential(FROM, "Sandhya@1995");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mailMessage);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
    }
}
