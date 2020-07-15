using System;

namespace FreeFundsApi.Models
{
    public class Bet
    {
        public long BetId { get; set; }
        public int SchemeID { get; set; }
        public int BetNumber { get; set; }
        public int CreatedBy { get; set; }
        public int BetAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
