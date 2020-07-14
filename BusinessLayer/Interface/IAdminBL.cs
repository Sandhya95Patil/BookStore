//-----------------------------------------------------------------------
// <copyright file="IAdminBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;

    public interface IAdminBL
    {
        ResponseModel AdminSignUp(ShowModel adminShowModel);
        LoginResponseModel AdminLogin(LoginShowModel adminLoginShowModel);
    }
}
