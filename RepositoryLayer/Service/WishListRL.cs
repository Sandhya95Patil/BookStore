using CommonLayer.Model;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
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
        public AddWishListModel AddBookToWishList(int userId, ShowWishListModel showWishListModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", userId));
                paramList.Add(new StoredProcedureParameterData("@BookId", showWishListModel.BookId));
                paramList.Add(new StoredProcedureParameterData("@IsUsed", true));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));

                DataTable table = databaseConnection.StoredProcedureExecuteReader("BookAddToWishList", paramList);
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

        public List<AddWishListModel> GetAllWishList(int userId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", userId));
                DataTable table =  databaseConnection.StoredProcedureExecuteReader("GetAllWishList", paramList);
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

        public string DeleteWishList(int userId, int wishListId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                SqlConnection sqlConnection = databaseConnection.GetConnection();
                SqlCommand sqlCommand = databaseConnection.GetCommand("DeleteWishList", sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@WishListId", wishListId);
                var response =  sqlCommand.ExecuteReader();
                sqlConnection.Close();
                if (response.Equals(0))
                {
                    return null;
                }
                else
                {
                    return "Delete Wish List Successfully";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
