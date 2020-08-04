using System;
using System.Collections.Generic;
using System.Text;

namespace FreeFundsApi.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionTypeId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string IpAddress { get; set; }
        public int UserId { get; set; }
        public int pin { get; set; }
    }
}

 