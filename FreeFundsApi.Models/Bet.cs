using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public bool Status { get; set; } = true;
        public int UserId { get; set; }
        public Users Users { get; set; }

    }
}
