using System.Collections.Generic;
using System.Threading.Tasks;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IAllGame
    {
        Task<bool> InsertGameAsync(AllGame allGame);
        Task<bool> CheckExistGameAsync(string allGame);
        Task<AllGameViewModel> GetGamebyIdAsync(long gameId);
        Task<bool> DeleteGameAsync(long gameId);
        Task<bool> UpdateGameAsync(AllGame allGame);
        Task<IEnumerable<AllGameViewModel>> GetAllGamesAsync();
    }
}