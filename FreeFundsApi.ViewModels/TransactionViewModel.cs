using System;
using System.Collections.Generic;
using System.Text;

namespace FreeFundsApi.ViewModels
{
    public class TransactionViewModel
    {
        public long TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal CurrentBal { get; set; }
        public int CreatedBy { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string IpAddress { get; set; }
        public long RecordId { get; set; }
        public int UserId { get; set; }
    }
}
