using CommonLayer.ResponseModel;
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
    public class PurchaseRL : IPurchaseRL
    {
        IConfiguration configuration;
        public PurchaseRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public PurchaseResponseModel BookPurchase(int userId, ShowPurchaseBookModel showPurchaseModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@UserId", userId));
                paramList.Add(new StoredProcedureParameterData("@CartId", showPurchaseModel.CartId));
                paramList.Add(new StoredProcedureParameterData("@BookId", showPurchaseModel.BookId));
                paramList.Add(new StoredProcedureParameterData("@IsUsed", true));
                paramList.Add(new StoredProcedureParameterData("@Address", showPurchaseModel.Address));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));

                DataTable table =  databaseConnection.StoredProcedureExecuteReader("PurchaseBook", paramList);
                var purchaseData = new PurchaseResponseModel();

                foreach (DataRow dataRow in table.Rows)
                {
                    purchaseData = new PurchaseResponseModel();
                    purchaseData.Id = Convert.ToInt32(dataRow["Id"]);
                    purchaseData.CartId = Convert.ToInt32(dataRow["CartId"]);
                    purchaseData.UserId = Convert.ToInt32(dataRow["UserId"].ToString());
                    purchaseData.BookId = Convert.ToInt32(dataRow["BookId"].ToString());
                    purchaseData.Address = dataRow["Address"].ToString().ToString();
                    purchaseData.Price = Convert.ToInt32(dataRow["Price"]);
                    purchaseData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    purchaseData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }
                return purchaseData;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
