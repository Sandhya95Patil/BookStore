using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        AddCart AddCart(int userId, ShowCartModel showCartModel);
        List<AddCart> GetAllCart(int userId);
        string DeleteCart(int userId, int cartId);

    }
}
