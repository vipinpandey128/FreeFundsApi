using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IWinning
    {
        Task<bool> InsertWinning(Winning Winning);
        Task<bool> CheckExistWinning(string Winning);
        Task<Winning> GetWinningbyId(int WinningId);
        Task<bool> DeleteWinning(int WinningId);
        Task<bool> UpdateWinning(Winning Winning);
        Task<List<Winning>> GetWinnings();
    }
}