//-----------------------------------------------------------------------
// <copyright file="UserRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Service
{
    using CommonLayer.Model;
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.EncryptedPassword;
    using RepositoryLayer.Interface;
    using RepositoryLayer.MSMQ;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class UserRL : IUserRL
    {
        IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// user signup method
        /// </summary>
        /// <param name="adminShowModel"></param>
        /// <returns></returns>
        public ResponseModel UserSignUp(ShowModel adminShowModel)
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
                DataTable table = databaseConnection.StoredProcedureExecuteReader("AddUser", paramList);
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
                    MSMQSender mSMQSender = new MSMQSender();
                    mSMQSender.Message(userData.Email);
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

        /// <summary>
        /// user login method
        /// </summary>
        /// <param name="loginShowModel"></param>
        /// <returns></returns>
        public LoginResponseModel UserLogin(LoginShowModel loginShowModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                var password = PasswordEncrypt.Encryptdata(loginShowModel.Password);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@Email", loginShowModel.Email));
                paramList.Add(new StoredProcedureParameterData("@Password", password));
                DataTable table = databaseConnection.StoredProcedureExecuteReader("UserLogin", paramList);
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
                        };
                        return responseShow;
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
