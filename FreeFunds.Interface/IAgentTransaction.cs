using FreeFundsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.Interface
{
    public interface IAgentTransaction
    {
        Task<IEnumerable<AgentTransactionViewModel>> getAllAgentTransaction(int agentId);
    }
}
