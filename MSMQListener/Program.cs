using Experimental.System.Messaging;
using System;

namespace MSMQListener
{

    class Program
    {

        public static void Main(string[] args)
        {
            string path = @".\Private$\myQueue";
            MSMQListener msmqListener = new MSMQListener(path);
            msmqListener.Start();
        }
    }
}
       
