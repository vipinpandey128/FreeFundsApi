using System;
using System.Collections.Generic;

namespace FreeFundsApi.Models
{
    public class Bet
    {
        public long BetId { get; set; }
        public int BetNumber { get; set; }
        public int CreatedBy { get; set; }
        public int BetAmount { get; set; }
        public decimal WinPer { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public virtual Users Users { get; set; }
        public long GameId { get; set; }
        public virtual AllGame AllGame { get; set; }
        public virtual List<AllTransaction> AllTransactions { get; set; }
    }
}
