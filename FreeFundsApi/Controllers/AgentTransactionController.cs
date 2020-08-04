using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentTransactionController : ControllerBase
    {
        private readonly IAgentTransaction _agentTransaction;

        public AgentTransactionController(IAgentTransaction agentTransaction)
        {
            _agentTransaction = agentTransaction;
        }

        // GET: api/AgentTransaction
        [HttpGet]
        public async Task<IEnumerable<AgentTransactionViewModel>> GetAllTransactions()
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _agentTransaction.getAllAgentTransaction(userId);
        }
    }
}