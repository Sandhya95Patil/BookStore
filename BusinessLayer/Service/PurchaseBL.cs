using BusinessLayer.Interface;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class PurchaseBL : IPurchaseBL
    {
        IPurchaseRL purchaseRL;
        public PurchaseBL(IPurchaseRL purchaseRL)
        {
            this.purchaseRL = purchaseRL;
        }

        public Task<PurchaseResponseModel> BookPurchase(ShowPurchaseBookModel showPurchaseModel)
        {
            try
            {
                var response = this.purchaseRL.BookPurchase(showPurchaseModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
