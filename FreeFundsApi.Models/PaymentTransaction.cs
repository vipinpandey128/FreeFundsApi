using System;
using System.Collections.Generic;
using System.Text;

namespace FreeFundsApi.Models
{
    public class PaymentTransaction
    {
        public long Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long TransactionId { get; set; }
    }
}
