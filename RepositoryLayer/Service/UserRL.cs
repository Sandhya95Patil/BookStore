using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.EncryptedPassword;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<ResponseModel> UserSignUp(ShowModel adminShowModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                var userType = "user";
                var password = PasswordEncrypt.Encryptdata(adminShowModel.Password);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@FirstName", adminShowModel.FirstName));
                paramList.Add(new StoredProcedureParameterData("@LastName", adminShowModel.LastName));
                paramList.Add(new StoredProcedureParameterData("@Email", adminShowModel.Email));
                paramList.Add(new StoredProcedureParameterData("@Password", password));
                paramList.Add(new StoredProcedureParameterData("@IsActive", adminShowModel.IsActive));
                paramList.Add(new StoredProcedureParameterData("@UserRole", userType));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("AddUser", paramList);
                var userData = new ResponseModel();

                foreach (DataRow dataRow in table.Rows)
                {
                    userData = new ResponseModel();
                    userData.Id = (int)dataRow["Id"];
                    userData.FirstName = dataRow["FirstName"].ToString();
                    userData.LastName = dataRow["LastName"].ToString();
                    userData.Email = dataRow["Email"].ToString();
                    userData.IsActive = Convert.ToBoolean(dataRow["IsActive"]);
                    userData.UserRole = dataRow["UserRole"].ToString();
                    userData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    userData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }
                if (userData.Email != null)
                {
                    return userData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
