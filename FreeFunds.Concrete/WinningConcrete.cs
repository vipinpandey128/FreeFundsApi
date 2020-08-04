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
    public class WinningConcrete : IWinning
    {

        private readonly DatabaseContext context;
        public WinningConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckExistWinning(string Winning)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWinning(int WinningId)
        {
            throw new NotImplementedException();
        }

        public Task<Winning> GetWinningbyId(int WinningId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Winning>> GetWinnings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertWinning(Winning Winning)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWinning(Winning Winning)
        {
            throw new NotImplementedException();
        }
    }
}
