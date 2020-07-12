using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Models;

namespace FreeFundsApi.Interface
{
  public  interface IPeriodMaster
    {
        List<PeriodTB> ListofPeriod();
    }
}
