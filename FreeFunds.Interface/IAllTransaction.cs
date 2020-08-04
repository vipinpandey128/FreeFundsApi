using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IAllTransaction
    {
        Task<long> InsertTransactionAsync(AllTransaction Transaction);
        Task<AllTransaction> GetTransactionbyIdAsync(int TransactionId);
        Task<List<AllTransaction>> GetTransactionsAsync();
    }
}