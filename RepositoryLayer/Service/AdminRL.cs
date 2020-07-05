using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.EncryptedPassword;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        IConfiguration configuration;
        public AdminRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method is for connection with database using connection string
        /// </summary>
        /// <param name="connectionName">connectionName parameter</param>
        /// <returns>return the connection</returns>
        public SqlConnection GetConnection(string connectionName)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Method for get command
        /// </summary>
        /// <param name="command">command parameter</param>
        /// <returns>return command</returns>
        public SqlCommand GetCommand(string command)
        {
            string connection = "";
            SqlConnection sqlConnection = GetConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        /// <summary>
        /// Stored Procedure Parameter Data class
        /// </summary>
        class StoredProcedureParameterData
        {
            public StoredProcedureParameterData(string name, dynamic value)
            {
                this.name = name;
                this.value = value;
            }

            public string name { get; set; }
            public dynamic value { get; set; }
        }

        /// <summary>
        /// Stored Procedure Execute Reader method
        /// </summary>
        /// <param name="spName">spName parameter</param>
        /// <param name="spParams">spParams parameter</param>
        /// <returns>return procedure name and parameters</returns>
        private async Task<DataTable> StoredProcedureExecuteReader(string spName, IList<StoredProcedureParameterData> spParams)
        {
            try
            {
                SqlCommand command = GetCommand(spName);
                for (int i = 0; i < spParams.Count; i++)
                {
                    command.Parameters.AddWithValue(spParams[i].name, spParams[i].value);
                }
                DataTable table = new DataTable();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                table.Load(dataReader);
                return table;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<AdminResponseModel> AdminSignUp(AdminShowModel adminShowModel)
        {
            try
            {
                var userType = "admin";
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
                DataTable table = await StoredProcedureExecuteReader("AddUser", paramList);
                var userData = new AdminResponseModel();

                foreach (DataRow dataRow in table.Rows)
                {
                    userData = new AdminResponseModel();
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

        public async Task<AdminLoginResponseModel> AdminLogin(AdminLoginShowModel adminLoginShowModel)
        {
            try
            {
                var password = PasswordEncrypt.Encryptdata(adminLoginShowModel.Password);

                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@Email", adminLoginShowModel.Email));
                paramList.Add(new StoredProcedureParameterData("@Password", password));
                paramList.Add(new StoredProcedureParameterData("@UserRole", adminLoginShowModel.UserRole));
                DataTable table = await StoredProcedureExecuteReader("AdminLogin", paramList);
                var userData = new AdminModel();
                foreach (DataRow dataRow in table.Rows)
                {
                    userData = new AdminModel();
                    userData.Id = (int)dataRow["Id"];
                    userData.FirstName = dataRow["FirstName"].ToString();
                    userData.LastName = dataRow["LastName"].ToString();
                    userData.Email = dataRow["Email"].ToString();
                    userData.Password = dataRow["Password"].ToString();
                    userData.IsActive = Convert.ToBoolean(dataRow["IsActive"]);
                    userData.UserRole = dataRow["UserRole"].ToString();
                    userData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    userData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }

                if (userData.Email != null)
                {
                    if (password.Equals(userData.Password))
                    {
                        ////Here generate encrypted key and result store in security key
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:token"]));

                        //// here using securitykey and algorithm(security) the credentials is generate(SigningCredentials present in Token)
                        var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new[] {
                         new Claim ("Id", userData.Id.ToString()),
                         new Claim("Email", userData.Email.ToString()),
                         new Claim("Password", userData.Password.ToString()),
                        };

                        var token = new JwtSecurityToken("Security token", "https://Test.com",
                            claims,
                            DateTime.UtcNow,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: creadintials);
                        var returnToken = new JwtSecurityTokenHandler().WriteToken(token);

                        var responseShow = new AdminLoginResponseModel()
                        {
                            Id = userData.Id,
                            FirstName = userData.FirstName,
                            LastName = userData.LastName,
                            Email = userData.Email,
                            IsActive = userData.IsActive,
                            UserRole = userData.UserRole,
                            CreatedDate = userData.CreatedDate,
                            ModifiedDate = userData.ModifiedDate,
                            Token = returnToken
                        };
                        return responseShow;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Email or Passord is Not Correct");
            }
        }
    }
}
