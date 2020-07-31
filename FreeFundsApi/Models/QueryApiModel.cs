using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeFundsApi.Models
{
    public class QueryApiModel
    {
        [FromQuery]
        public string Query1 { get; set; }
        [FromQuery]
        public int Query2 { get; set; }
    }

}
