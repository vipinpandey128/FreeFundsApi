using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Contactno { get; set; }
        public string Password { get; set; }
        public int? Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CurrentBal { get; set; }
        public int WithDrawalPin { get; set; }
        public bool IsTermsAndConditions { get; set; }
        public bool IsPasswordUpdated { get; set; }
        public bool Status { get; set; }
        public virtual List<LoginStatus> LoginStatus { get; set; }
        public virtual List<Winning> Winnings { get; set; }
        public virtual List<AllTransaction> AllTransactions { get; set; }
        public virtual List<Bet> Bets { get; set; }
        public virtual List<UsersInRoles> UsersInRoles { get; set; }
    }

}
