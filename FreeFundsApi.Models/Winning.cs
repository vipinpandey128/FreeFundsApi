using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeFundsApi.Models
{
    public class Winning
    {
        public long WinId { get; set; }
        public long BetId { get; set; }
        public decimal WinAmount { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
