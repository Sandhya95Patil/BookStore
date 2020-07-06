using CommonLayer.Model;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class WishListRL : IWishListRL
    {
        IConfiguration configuration;
        public WishListRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<AddWishListModel> AddBookToWishList(ShowWishListModel showWishListModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", showWishListModel.UserId));
                paramList.Add(new StoredProcedureParameterData("@BookId", showWishListModel.BookId));
                paramList.Add(new StoredProcedureParameterData("@IsUsed", true));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));

                DataTable table = await databaseConnection.StoredProcedureExecuteReader("AddCart", paramList);
                var wishListData = new AddWishListModel();

                foreach (DataRow dataRow in table.Rows)
                {
                    wishListData = new AddWishListModel();
                    wishListData.Id = (int)dataRow["Id"];
                    wishListData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    wishListData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    wishListData.IsUsed = Convert.ToBoolean(dataRow["IsUsed"].ToString());
                    wishListData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    wishListData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }
                return wishListData;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<List<AddWishListModel>> GetAllWishList()
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("GetAllWishList", paramList);
                var wishListData = new AddWishListModel();
                List<AddWishListModel> wishLists = new List<AddWishListModel>();

                foreach (DataRow dataRow in table.Rows)
                {
                    wishListData = new AddWishListModel();
                    wishListData.Id = (int)dataRow["Id"];
                    wishListData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    wishListData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    wishListData.IsUsed = Convert.ToBoolean(dataRow["IsUsed"].ToString());
                    wishListData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    wishListData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                    wishLists.Add(wishListData);
                }
                if (wishLists.Count != 0)
                {
                    return wishLists;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
