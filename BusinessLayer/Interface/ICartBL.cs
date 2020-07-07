using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        Task<AddCart> AddCart(ShowCartModel showCartModel);
        Task<List<AddCart>> GetAllCart();
        Task<List<AddCart>> GetCartByCartId(int cartId);

        Task<string> DeleteCart(int cartId);
    }
}
