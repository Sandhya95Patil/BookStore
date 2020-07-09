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
