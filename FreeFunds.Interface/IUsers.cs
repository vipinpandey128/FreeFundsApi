using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IUsers
    {
        Task<bool> InsertUsersAsync(Users user);
        Task<bool> CheckUsersExitsAsync(string username);
        Task<Users> GetUsersbyIdAsync(int userid);
        Task<bool> DeleteUsersAsync(int userid);
        Task<bool> UpdateUsersAsync(Users role);
        Task<List<Users>> GetAllUsersAsync();
        Task<bool> AuthenticateUsersAsync(string username, string password);
        Task<LoginResponse> GetUserDetailsbyCredentialsAsync(string username);
        Task<UsersViewModel> GetUserDetailsByFilterTypeAsync(string searchData, int filterType);
        Task<decimal> CheckUserBalanceAsync(int userid);
    }
}