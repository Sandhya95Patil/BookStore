
namespace RepositoryLayer.Service
{
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// cart class
    /// </summary>
    public class CartRL : ICartRL
    {
        /// <summary>
        /// create field for configuration
        /// </summary>
        IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// add cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="showCartModel"></param>
        /// <returns></returns>
        public  AddCart AddCart(int userId, ShowCartModel showCartModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", userId));
                paramList.Add(new StoredProcedureParameterData("@BookId", showCartModel.BookId));
                paramList.Add(new StoredProcedureParameterData("@IsUsed", false));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));
        
                DataTable table =  databaseConnection.StoredProcedureExecuteReader("AddCart", paramList);
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

        public string DeleteCart(int userId, int cartId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                SqlConnection sqlConnection = databaseConnection.GetConnection();
                SqlCommand sqlCommand = databaseConnection.GetCommand("DeleteCart", sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@CartId", cartId);
                var response = sqlCommand.ExecuteReader();
                sqlConnection.Close();

                if (response.Equals(0))
                {
                    return null;
                }
                else
                {
                    return "Delete Cart Successfully";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AddCart> GetAllCart(int userId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", userId));
                DataTable table =  databaseConnection.StoredProcedureExecuteReader("GetAllCart", paramList);
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
