using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreeFundsApi.Models
{
    public class TransactionType
    {
        public int TransationTypeId { get; set; }
        [MaxLength(50)]
        public string TransactionTypeName { get; set; }
        public bool IsActive { get; set; }
        public virtual List<AllTransaction> AllTransactions { get; set; }

    }
}
