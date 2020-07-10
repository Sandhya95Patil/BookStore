﻿using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IPurchaseRL
    {
        PurchaseResponseModel BookPurchase(int userId, ShowPurchaseBookModel showPurchaseModel);

    }
}