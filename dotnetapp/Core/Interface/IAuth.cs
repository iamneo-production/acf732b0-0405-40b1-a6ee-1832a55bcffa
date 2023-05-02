using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Core.Interface
{
    public interface IAuth 
    {
        Task<ResponseModel> RegisterUser(UserModel userModel);
        ResponseModel GenerateToken(LoginModel loginModel);
    }
}
