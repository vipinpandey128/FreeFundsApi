using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Concrete
{
    public class TransactionTypeConcrete : ITransactionType
    {

        private readonly DatabaseContext context;
        public TransactionTypeConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckExistTransactionType(string TransactionType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionType(int TransactionTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionType> GetTransactionTypebyId(int TransactionTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionType>> GetTransactionTypes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertTransactionType(TransactionType TransactionType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTransactionType(TransactionType TransactionType)
        {
            throw new NotImplementedException();
        }
    }
}
