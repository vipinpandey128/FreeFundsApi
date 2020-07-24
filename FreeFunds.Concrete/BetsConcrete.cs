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
    public class BetsConcrete : IBet
    {

        private readonly DatabaseContext context;
        public BetsConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckExistBet(string Bet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBet(int BetId)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> GetBetbyId(int BetId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bet>> GetBets()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertBet(Bet Bet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBet(Bet Bet)
        {
            throw new NotImplementedException();
        }
    }
}
