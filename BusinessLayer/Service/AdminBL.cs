//-----------------------------------------------------------------------
// <copyright file="AdminBL.cs" company="BridgeLabz Solution">
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

    public class AdminBL : IAdminBL
    {
        IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public ResponseModel AdminSignUp(ShowModel adminShowModel)
        {
            try
            {
                var response = this.adminRL.AdminSignUp(adminShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public LoginResponseModel AdminLogin(LoginShowModel adminLoginShowModel)
        {
            try
            {
                var response = this.adminRL.AdminLogin(adminLoginShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
