using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeFundsApi.Models
{
    public class AllGame
    {
        public long GameId { get; set; }
        public string GameName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Bet> Bets { get; set; }
        public int SchemeID { get; set; }
        public virtual SchemeMaster SchemeMaster { get; set; }
    }
}
