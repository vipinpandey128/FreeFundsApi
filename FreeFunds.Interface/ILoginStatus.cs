using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface ILoginStatus
    {
        Task<bool> InsertLoginStatusAsync(LoginStatus LoginStatus);
        Task<IEnumerable<LoginStatus>> GetLoginStatusAsync();
    }
}