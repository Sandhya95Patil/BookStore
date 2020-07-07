using CommonLayer.Model;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<AddCart> AddCart(ShowCartModel showCartModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", showCartModel.UserId));
                paramList.Add(new StoredProcedureParameterData("@BookId", showCartModel.BookId));
                paramList.Add(new StoredProcedureParameterData("@IsUsed", true));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));
        
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("AddCart", paramList);
                var cartData = new AddCart();

                foreach (DataRow dataRow in table.Rows)
                {
                    cartData = new AddCart();
                    cartData.CartId = (int)dataRow["Id"];
                    cartData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    cartData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    cartData.IsUsed = Convert.ToBoolean(dataRow["IsUsed"].ToString());
                    cartData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    cartData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }
                return cartData;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<string> DeleteCart(int cartId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                SqlConnection sqlConnection = databaseConnection.GetConnection();
                SqlCommand sqlCommand = databaseConnection.GetCommand("DeleteWishList", sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CartId", cartId);
                sqlConnection.Close();

                var response = await sqlCommand.ExecuteNonQueryAsync();
                if (response > 0)
                {
                    return "Delete Cart Successfully";
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

        public async Task<List<AddCart>> GetAllCart()
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("GetAllCart", paramList);
                var cartData = new AddCart();
                List<AddCart> cartLists = new List<AddCart>();

                foreach (DataRow dataRow in table.Rows)
                {
                    cartData = new AddCart();
                    cartData.CartId = (int)dataRow["Id"];
                    cartData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    cartData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    cartData.IsUsed = Convert.ToBoolean(dataRow["IsUsed"].ToString());
                    cartData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    cartData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                    cartLists.Add(cartData);
                }
                if (cartLists.Count != 0)
                {
                    return cartLists;
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

        public async Task<List<AddCart>> GetCartByCartId(int cartId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@CartId", cartId));
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("GetCartByCartId", paramList);
                var cartData = new AddCart();
                List<AddCart> cartLists = new List<AddCart>();

                foreach (DataRow dataRow in table.Rows)
                {
                    cartData = new AddCart();
                    cartData.CartId = (int)dataRow["Id"];
                    cartData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    cartData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    cartData.IsUsed = Convert.ToBoolean(dataRow["IsUsed"].ToString());
                    cartData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    cartData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                    cartLists.Add(cartData);
                }
                if (cartLists.Count != 0)
                {
                    return cartLists;
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
