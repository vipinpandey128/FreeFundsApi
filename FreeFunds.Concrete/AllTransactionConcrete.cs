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
    public class AllTransactionConcrete : IAllTransaction
    {

        private readonly DatabaseContext context;
        public AllTransactionConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckExistTransaction(string Transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransaction(int TransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<AllTransaction> GetTransactionbyId(int TransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AllTransaction>> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertTransaction(AllTransaction Transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTransaction(AllTransaction Transaction)
        {
            throw new NotImplementedException();
        }
    }
}
