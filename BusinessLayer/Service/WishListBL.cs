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
    public class WishListBL : IWishListBL
    {
        IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public Task<AddWishListModel> AddBookToWishList(ShowWishListModel showWishListModel)
        {
            try
            {
                var response = this.wishListRL.AddBookToWishList(showWishListModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<AddWishListModel>> GetAllWishList()
        {
            try
            {
                var response = this.wishListRL.GetAllWishList();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public Task<bool> DeleteWishList(int wishListId)
        {
            try
            {
                var response = this.wishListRL.DeleteWishList(wishListId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
