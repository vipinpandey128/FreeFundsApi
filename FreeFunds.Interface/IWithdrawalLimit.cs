using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IWithdrawalLimit
    {
        Task<bool> InsertWithdrawalLimit(WithdrawalLimit WithdrawalLimit);
        Task<bool> CheckExistWithdrawalLimit(string WithdrawalLimit);
        Task<WithdrawalLimit> GetWithdrawalLimitbyId(int WithdrawalLimitId);
        Task<bool> DeleteWithdrawalLimit(int WithdrawalLimitId);
        Task<bool> UpdateWithdrawalLimit(WithdrawalLimit WithdrawalLimit);
        Task<List<WithdrawalLimit>> GetWithdrawalLimits();
    }
}