//-----------------------------------------------------------------------
// <copyright file="IUserRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;

    /// <summary>
    /// interface of user 
    /// </summary>
    public interface IUserRL
    {
        ResponseModel UserSignUp(ShowModel adminShowModel);
        LoginResponseModel UserLogin(LoginShowModel adminLoginShowModel);

    }
}
