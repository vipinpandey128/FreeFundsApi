using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.Models
{
    public class UsersInRoles
    {
        public int UserRolesId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
