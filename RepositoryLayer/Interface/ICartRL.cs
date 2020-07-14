//-----------------------------------------------------------------------
// <copyright file="ICartRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using System.Collections.Generic;

    /// <summary>
    /// interface of cart 
    /// </summary>
    public interface ICartRL
    {
        AddCart AddCart(int userId, ShowCartModel showCartModel);
        List<AddCart> GetAllCart(int userId);
        string DeleteCart(int userId, int cartId);

    }
}
