using System.Collections.Generic;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IUsers
    {
        bool InsertUsers(Users user);
        bool CheckUsersExits(string username);
        Users GetUsersbyId(int userid);
        bool DeleteUsers(int userid);
        bool UpdateUsers(Users role);
        List<Users> GetAllUsers();
        bool AuthenticateUsers(string username, string password);
        LoginResponse GetUserDetailsbyCredentials(string username);
    }
}