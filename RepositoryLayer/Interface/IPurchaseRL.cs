//-----------------------------------------------------------------------
// <copyright file="IPurchaseRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;

    /// <summary>
    /// interface of purchase
    /// </summary>
    public interface IPurchaseRL
    {
        PurchaseResponseModel BookPurchase(int userId, ShowPurchaseBookModel showPurchaseModel);

    }
}
