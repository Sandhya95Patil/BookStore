using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Task<AddWishListModel> AddBookToWishList(int userId, ShowWishListModel showWishListModel)
        {
            try
            {
                var response = this.wishListRL.AddBookToWishList(userId, showWishListModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<AddWishListModel>> GetAllWishList(int userId)
        {
            try
            {
                var response = this.wishListRL.GetAllWishList(userId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public Task<string> DeleteWishList(int userId, int wishListId)
        {
            try
            {
                var response = this.wishListRL.DeleteWishList(userId, wishListId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
