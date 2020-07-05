using BusinessLayer.Interface;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public Task<ResponseModel> AdminSignUp(ShowModel adminShowModel)
        {
            try
            {
                var response = this.adminRL.AdminSignUp(adminShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<LoginResponseModel> AdminLogin(LoginShowModel adminLoginShowModel)
        {
            try
            {
                var response = this.adminRL.AdminLogin(adminLoginShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
