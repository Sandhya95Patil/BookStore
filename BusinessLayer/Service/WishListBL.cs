//-----------------------------------------------------------------------
// <copyright file="WishListBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Service
{
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Wish list class
    /// </summary>
    public class WishListBL : IWishListBL
    {
        IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public AddWishListModel AddBookToWishList(int userId, ShowWishListModel showWishListModel)
        {
            try
            {
                var response = this.wishListRL.AddBookToWishList(userId, showWishListModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<AddWishListModel> GetAllWishList(int userId)
        {
            try
            {
                var response = this.wishListRL.GetAllWishList(userId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public string DeleteWishList(int userId, int wishListId)
        {
            try
            {
                var response = this.wishListRL.DeleteWishList(userId, wishListId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
