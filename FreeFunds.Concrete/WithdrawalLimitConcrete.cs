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
    public class WithdrawalLimitConcrete : IWithdrawalLimit
    {

        private readonly DatabaseContext context;
        public WithdrawalLimitConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckExistWithdrawalLimit(string WithdrawalLimit)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWithdrawalLimit(int WithdrawalLimitId)
        {
            throw new NotImplementedException();
        }

        public Task<WithdrawalLimit> GetWithdrawalLimitbyId(int WithdrawalLimitId)
        {
            throw new NotImplementedException();
        }

        public Task<List<WithdrawalLimit>> GetWithdrawalLimits()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertWithdrawalLimit(WithdrawalLimit WithdrawalLimit)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWithdrawalLimit(WithdrawalLimit WithdrawalLimit)
        {
            throw new NotImplementedException();
        }
    }
}
