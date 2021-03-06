﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFundsApi.Models
{
    public class SchemeMaster
    {
        public int SchemeID { get; set; }
        public string SchemeName { get; set; }
        public decimal WinPer { get; set; }
        public int Createdby { get; set; }
        public DateTime Createddate { get; set; }
        public bool Status { get; set; }
        public virtual List<AllGame> AllGames { get; set; }
    }
}
