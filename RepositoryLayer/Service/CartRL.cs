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
    }
}
