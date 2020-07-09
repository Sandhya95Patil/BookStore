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
        Task<AddWishListModel> AddBookToWishList(int userId, ShowWishListModel showWishListModel);
        Task<List<AddWishListModel>> GetAllWishList(int userId);
        Task<string> DeleteWishList(int userId, int wishListId);

    }
}
