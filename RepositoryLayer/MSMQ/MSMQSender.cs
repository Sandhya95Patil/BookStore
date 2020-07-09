using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.MSMQ
{
    public class MSMQSender
    {
        public void Message(string emailMessage)
        {
            MessageQueue MyQueue;
            if (MessageQueue.Exists(@".\Private$\myqueue"))
            {
                MyQueue = new MessageQueue(@".\Private$\myqueue");
            }
            else
            {
                MyQueue = MessageQueue.Create(@".\Private$\myqueue");
            }
            Message MyMessage = new Message();
            MyMessage.Formatter = new BinaryMessageFormatter();
            MyMessage.Body = emailMessage;
            MyMessage.Label = "Registration";
            MyMessage.Priority = MessagePriority.Normal;
            MyQueue.Send(MyMessage, emailMessage);
        }
    }
}

