using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IAllTransaction
    {
        Task<bool> InsertTransaction(AllTransaction Transaction);
        Task<bool> CheckExistTransaction(string Transaction);
        Task<AllTransaction> GetTransactionbyId(int TransactionId);
        Task<bool> DeleteTransaction(int TransactionId);
        Task<bool> UpdateTransaction(AllTransaction Transaction);
        Task<List<AllTransaction>> GetTransactions();
    }
}