//-----------------------------------------------------------------------
// <copyright file="PurchaseBL.cs" company="BridgeLabz Solution">
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
    /// Purchase Classs
    /// </summary>
    public class PurchaseBL : IPurchaseBL
    {
        IPurchaseRL purchaseRL;
        public PurchaseBL(IPurchaseRL purchaseRL)
        {
            this.purchaseRL = purchaseRL;
        }

        public PurchaseResponseModel BookPurchase(int userId, ShowPurchaseBookModel showPurchaseModel)
        {
            try
            {
                var response = this.purchaseRL.BookPurchase(userId, showPurchaseModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
