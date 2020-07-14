//-----------------------------------------------------------------------
// <copyright file="UserBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Service
{
    using BusinessLayer.Interface;
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;
    using RepositoryLayer.Interface;
    using System;

    /// <summary>
    /// User class
    /// </summary>
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        /// <summary>
        /// user sign up method
        /// </summary>
        /// <param name="adminShowModel"></param>
        /// <returns></returns>
        public ResponseModel UserSignUp(ShowModel adminShowModel)
        {
            try
            {
                var response = this.userRL.UserSignUp(adminShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public LoginResponseModel UserLogin(LoginShowModel loginShowModel)
        {
            try
            {
                var response = this.userRL.UserLogin(loginShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
