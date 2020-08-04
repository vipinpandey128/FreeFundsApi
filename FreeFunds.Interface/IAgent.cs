using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IAgent
    {
        Task<bool> InsertUsersAsync(Users user);
        Task<bool> CheckUsersExitsAsync(string username);
        Task<Users> GetUsersbyIdAsync(int userid, int cretedById);
        Task<bool> DeleteUsersAsync(int userid, int loginId);
        Task<bool> UpdateUsersAsync(Users role);
        Task<List<Users>> GetAllUsersAsync(int loginId);
        Task<LoginResponse> GetUserDetailsbyCredentialsAsync(string username, int loginId);
        Task<UsersViewModel> GetAgentUserDetailsByFilterTypeAsync(string searchData, int filterType, int loginId);
        Task<decimal> CheckUserBalanceAsync(int userid, int loginId);
        Task<decimal> CheckAgentBalanceAsync(int agentId);
    }
}