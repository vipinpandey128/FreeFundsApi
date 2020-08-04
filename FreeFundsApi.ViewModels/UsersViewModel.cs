using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Contactno { get; set; }
        [Required]
        public string Password { get; set; }
        public decimal CurrentBal { get; set; }
        public bool Status { get; set; }
    }

    public class UsersProfileViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Contactno { get; set; }
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int WithDrawalPin { get; set; }
        public decimal CurrentBal { get; set; }
        public bool Status { get; set; }
    }
}
