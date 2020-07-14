//-----------------------------------------------------------------------
// <copyright file="MailSender.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Service
{
    using System;
    using System.Net;
    using System.Net.Mail;

    /// <summary>
    /// mail sender class
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="data"></param>
        /// <param name="email"></param>
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
