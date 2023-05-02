using dotnetapp.Models;

namespace dotnetapp.Core.Interface
{
    public interface IUser
    {
        string addUser(UserModel data);
        UserModel getUser(string UserID);
        string editUser(UserModel data);
        string deleteUser(string UserID);
    }
}
