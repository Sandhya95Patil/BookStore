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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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


        public async Task<LoginResponseModel> UserLogin(LoginShowModel loginShowModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                var password = PasswordEncrypt.Encryptdata(loginShowModel.Password);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@Email", loginShowModel.Email));
                paramList.Add(new StoredProcedureParameterData("@Password", password));
                DataTable table = await databaseConnection.StoredProcedureExecuteReader("UserLogin", paramList);
                var userData = new RegisterModel();
                foreach (DataRow dataRow in table.Rows)
                {
                    userData = new RegisterModel();
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
                         new Claim("UserRole", userData.UserRole.ToString())
                        };

                        var token = new JwtSecurityToken("Security token", "https://Test.com",
                            claims,
                            DateTime.UtcNow,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: creadintials);
                        var returnToken = new JwtSecurityTokenHandler().WriteToken(token);

                        var responseShow = new LoginResponseModel()
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
