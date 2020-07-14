//-----------------------------------------------------------------------
// <copyright file="IAdminRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;

    /// <summary>
    /// Inerface of admin 
    /// </summary>
    public interface IAdminRL
    {
        ResponseModel AdminSignUp(ShowModel adminShowModel);
        LoginResponseModel AdminLogin(LoginShowModel adminLoginShowModel);
    }
}
