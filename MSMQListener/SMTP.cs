//-----------------------------------------------------------------------
// <copyright file="SMTP.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//---------------------------------------------------------------------
namespace MSMQListener
{
    using System;
    using System.Net;
    using System.Net.Mail;

    public class SMTP
    {
        public static bool SendMail(string data, string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email))
                {

                    string FROMNAME = "Sandhya", FROM = "sandhyapatil364@gmail.com", TO = email, SUBJECT = "Registration";
                    int PORT = 587;
                    string message = "Your Registration Successfully Completed";
                    var BODY = "Hi , " + message;

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
