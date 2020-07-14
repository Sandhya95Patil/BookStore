//-----------------------------------------------------------------------
// <copyright file="MSMQSender.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
using Experimental.System.Messaging;

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

