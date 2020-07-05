using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        Task<ResponseModel> AdminSignUp(ShowModel adminShowModel);
        Task<LoginResponseModel> AdminLogin(LoginShowModel adminLoginShowModel);
    }
}
