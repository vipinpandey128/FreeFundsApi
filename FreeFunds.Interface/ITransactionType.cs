using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface ITransactionType
    {
        Task<bool> InsertTransactionType(TransactionType TransactionType);
        Task<bool> CheckExistTransactionType(string TransactionType);
        Task<TransactionType> GetTransactionTypebyId(int TransactionTypeId);
        Task<bool> DeleteTransactionType(int TransactionTypeId);
        Task<bool> UpdateTransactionType(TransactionType TransactionType);
        Task<List<TransactionType>> GetTransactionTypes();
    }
}