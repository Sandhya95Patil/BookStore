using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQ
{
    class ReceiveMaessge
    {
        /// <summary>
        /// Receives the message from queue.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        public static void ReceiveMessageFromQueue(string queueName)
        {
            MessageQueue msMq = new MessageQueue(queueName);

            try
            {
                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                ////var message = msMq.Receive().Body;
                var lable = msMq.Receive().Label;
                ////Console.WriteLine(lable + "  " + message);

                Console.WriteLine(lable);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally
            {
                msMq.Close();
            }

            Console.WriteLine("Message received ......");
        }
}
