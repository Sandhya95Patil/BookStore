using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public Task<AddCart> AddCart(ShowCartModel showCartModel)
        {
            try
            {
                var response = this.cartRL.AddCart(showCartModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<AddCart>> GetAllCart()
        {
            try
            {
                var response = this.cartRL.GetAllCart();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<string> DeleteCart(int cartId)
        {
            try
            {
                var response = this.cartRL.DeleteCart(cartId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
