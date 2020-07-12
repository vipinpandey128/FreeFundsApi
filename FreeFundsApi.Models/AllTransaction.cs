using FreeFundsApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeFundsApi.Models
{
    [Table("AllTransaction")]
    public class AllTransaction
    {
        [Key]
        public long TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public long BetId { get; set; }
        public decimal BetAmount { get; set; }
        public decimal CurrentBal { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string IpAddress { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
