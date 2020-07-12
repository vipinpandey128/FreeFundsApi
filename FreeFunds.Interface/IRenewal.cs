using System;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IRenewal
    {
        RenewalViewModel GetMemberNo(string memberNo, int userid);
        bool CheckRenewalPaymentExists(DateTime newdate, long memberId);
    }
}