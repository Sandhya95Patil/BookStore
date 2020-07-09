using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public ResponseModel UserSignUp(ShowModel adminShowModel)
        {
            try
            {
                var response = this.userRL.UserSignUp(adminShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public LoginResponseModel UserLogin(LoginShowModel loginShowModel)
        {
            try
            {
                var response = this.userRL.UserLogin(loginShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
