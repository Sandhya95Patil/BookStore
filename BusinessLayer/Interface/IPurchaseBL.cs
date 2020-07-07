﻿using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPurchaseBL
    {
        Task<PurchaseResponseModel> BookPurchase(ShowPurchaseBookModel showPurchaseModel);
    }
}
