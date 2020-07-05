using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        Task<ResponseModel> UserSignUp(ShowModel adminShowModel);
        Task<LoginResponseModel> UserLogin(LoginShowModel adminLoginShowModel);

    }
}
