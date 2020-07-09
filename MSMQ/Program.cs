using System;

namespace MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://localhost:44383";
            string queueName = @".\Private$\ForgetQueue";
            MessageQueue msMq = new MessageQueue(queueName);
            if (MessageQueue.Exists(queueName))
            {
                Console.WriteLine("Queue Read.....");
                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                ////var message = msMq.Receive().Body;
                var lable = msMq.Receive().Label;
                ////Console.WriteLine(lable + "  " + message);

                Console.WriteLine(lable);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                ////email address for sending mail.
                mail.From = new MailAddress("sandhyapatil364@gmail.com");

                ////email address to receive the mail.
                mail.To.Add("sandhyapatil364@gmail.com");

                ////subject of mail.
                mail.Subject = "Test MSMQ And SMTP";
                mail.Body = "<h4><a href=" + url + "/> Click here</a></h4> to reset the password \n" + lable;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sandhyapatil364@gmail.com", "Sandhya@1995");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Link Has Been Sent To Your Mail Address");
            }
            else
            {
                Console.WriteLine("Queue Empty....");
            }

            Console.ReadKey();
        }
    }
}
