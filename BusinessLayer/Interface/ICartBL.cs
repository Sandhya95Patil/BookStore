﻿using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        Task<AddCart> AddCart(int userId, ShowCartModel showCartModel);
        Task<List<AddCart>> GetAllCart(int userId);
        Task<string> DeleteCart(int userId, int cartId);
    }
}
