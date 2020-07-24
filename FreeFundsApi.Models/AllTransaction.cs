
using System;

namespace FreeFundsApi.Models
{
    public class AllTransaction
    {
        public long TransactionId { get; set; }
        public decimal BetAmount { get; set; }
        public decimal CurrentBal { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string IpAddress { get; set; }
        public int? UserId { get; set; }
        public virtual Users Users { get; set; }
        public long? BetId { get; set; }
        public virtual Bet Bets { get; set; }
        public int? TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }

    }
}
