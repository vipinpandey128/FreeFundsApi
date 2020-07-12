using System.Linq;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IPaymentDetails
    {
        IQueryable<PaymentDetailsViewModel> GetAll(QueryParameters queryParameters, int userId);
        int Count(int userId);
        bool RenewalPayment(RenewalViewModel renewalViewModel);
    }
}