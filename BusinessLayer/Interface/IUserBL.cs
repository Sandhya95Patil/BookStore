using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        Task<ResponseModel> UserSignUp(ShowModel adminShowModel);

    }
}
