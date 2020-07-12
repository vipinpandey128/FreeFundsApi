using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeFundsApi.Models
{
    [Table("AllGame")]
    public class AllGame
    {
        [Key]
        public long GameId { get; set; }
        public string GameName { get; set; }
        public int SchemeId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
