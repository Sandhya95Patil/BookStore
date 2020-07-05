using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        Task<ResponseModel> AdminSignUp(ShowModel adminShowModel);
        Task<LoginResponseModel> AdminLogin(AdminLoginShowModel adminLoginShowModel);
    }
}
