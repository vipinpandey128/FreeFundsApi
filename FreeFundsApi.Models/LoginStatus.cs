using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace FreeFundsApi.Models
{
    public class LoginStatus
    {
        public long LoginStatusId { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
