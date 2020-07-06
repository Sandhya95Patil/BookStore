using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        Task<AddWishListModel> AddBookToWishList(ShowWishListModel showWishListModel);
        Task<List<AddWishListModel>> GetAllWishList();
        Task<bool> DeleteWishList(int wishListId);
    }
}
