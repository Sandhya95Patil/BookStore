//-----------------------------------------------------------------------
// <copyright file="PasswordEncrypt.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//---------------------------------------------------------------------
namespace RepositoryLayer.EncryptedPassword
{
    using System;
    using System.Text;

    /// <summary>
    /// Password encrypt class
    /// </summary>
    public class PasswordEncrypt
    {
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
    }
}
