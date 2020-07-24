using System;
using System.Collections.Generic;
using System.Text;

namespace FreeFundsApi.ViewModels
{
    public class AllGameViewModel
    {
        public long GameId { get; set; }
        public string GameName { get; set; }
        public string SchemeName { get; set; }
        public decimal WinPer { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
