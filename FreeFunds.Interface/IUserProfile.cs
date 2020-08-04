using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.Interface
{
    public interface IUserProfile
    {
        Task<Users> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserProfileAsync(Users userProfile);
        Task<IEnumerable<AgentTransactionViewModel>> getAllAgentTransaction(int agentId);
    }
}
