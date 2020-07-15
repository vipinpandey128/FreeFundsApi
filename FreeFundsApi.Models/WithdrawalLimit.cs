using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeFundsApi.Models
{
    public class WithdrawalLimit
    {
        public int Id { get; set; }
        public int MaxWithdrawalBal { get; set; }
        public int IsActive { get; set; }
    }
}
