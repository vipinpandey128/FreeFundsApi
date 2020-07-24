using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Concrete
{
    public class LoginStatusConcrete : ILoginStatus
    {

        private readonly DatabaseContext context;
        public LoginStatusConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<IEnumerable<LoginStatus>> GetLoginStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertLoginStatusAsync(LoginStatus LoginStatus)
        {
            throw new NotImplementedException();
        }

    }
}
