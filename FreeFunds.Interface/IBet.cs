using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IBet
    {
        Task<bool> InsertBet(Bet Bet);
        Task<bool> CheckExistBet(string Bet);
        Task<Bet> GetBetbyId(int BetId);
        Task<bool> DeleteBet(int BetId);
        Task<bool> UpdateBet(Bet Bet);
        Task<List<Bet>> GetBets();
    }
}