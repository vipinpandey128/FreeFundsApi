using System;
using System.Collections.Generic;
using System.Text;

namespace FreeFundsApi.ViewModels
{
    public class AgentTransactionViewModel
    {
        public string GameName { get; set; }
        public long BetNumber { get; set; }
        public decimal BetAmount { get; set; }
        public decimal WinPer { get; set; }
        public string TransactionTypeName { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public string SchemeName { get; set; }

    }
}
