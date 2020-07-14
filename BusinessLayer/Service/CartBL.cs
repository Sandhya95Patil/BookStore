//-----------------------------------------------------------------------
// <copyright file="CartBL.cs" company="BridgeLabz Solution">
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
    /// Cart class
    /// </summary>
    public class CartBL : ICartBL
    {
        ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public AddCart AddCart(int userId, ShowCartModel showCartModel)
        {
            try
            {
                var response = this.cartRL.AddCart(userId, showCartModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<AddCart> GetAllCart(int userId)
        {
            try
            {
                var response = this.cartRL.GetAllCart(userId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string DeleteCart(int userId, int cartId)
        {
            try
            {
                var response = this.cartRL.DeleteCart(userId, cartId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
