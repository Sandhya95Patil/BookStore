//-----------------------------------------------------------------------
// <copyright file="IWishListRL.cs" company="BridgeLabz Solution">
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
    /// interface of wish list
    /// </summary>
    public interface IWishListRL
    {
        AddWishListModel AddBookToWishList(int userId, ShowWishListModel showWishListModel);
        List<AddWishListModel> GetAllWishList(int userId);
        string DeleteWishList(int userId, int wishListId);

    }
}
