using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FreeFundsApi.Concrete
{
    public class AgentTransactionConcrete : IAgentTransaction
    {

        private readonly DatabaseContext context;
        public AgentTransactionConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AgentTransactionViewModel>> getAllAgentTransaction(int agentId)
        {
            return await
                (from user in context.Users
                 join transaction in context.AllTransactions on user.UserId equals transaction.UserId
                 join TRTY in context.TransactionTypes on transaction.TransactionTypeId equals TRTY.TransationTypeId
                 where transaction.CreatedBy==agentId
                 select new AgentTransactionViewModel {
                 TransactionAmount = transaction.TransactionAmount,
                 BetAmount = 0,
                 BetNumber=0,
                 DateTime = transaction.CreatedDate,
                 GameName = "",
                 SchemeName= "",
                 TransactionTypeName = TRTY.TransactionTypeName,
                 Username = user.UserName,
                 WinPer = 0
                 }).ToListAsync();
        }
    }
}
