//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//---------------------------------------------------------------------
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
       
