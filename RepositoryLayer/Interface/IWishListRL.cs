using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        AddWishListModel AddBookToWishList(int userId, ShowWishListModel showWishListModel);
        List<AddWishListModel> GetAllWishList(int userId);
        string DeleteWishList(int userId, int wishListId);

    }
}
