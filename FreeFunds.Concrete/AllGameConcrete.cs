using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FreeFundsApi.Concrete
{
    public class AllGameConcrete : IAllGame
    {

        private readonly DatabaseContext context;
        public AllGameConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckExistGameAsync(string gameName)
        {
            if (await context.AllGames.Where(ee => ee.GameName == gameName).CountAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGameAsync(long gameId)
        {

            context.Entry(context.AllGames.Find(gameId)).State = EntityState.Deleted;
            if (await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<AllGameViewModel>> GetAllGamesAsync()
        {
            return await (from game in context.AllGames
                          join sch in context.SchemeMaster on game.SchemeID equals sch.SchemeID
                          select new AllGameViewModel
                          {
                              GameId = game.GameId,
                              GameName = game.GameName,
                              SchemeName = sch.SchemeName
                          ,
                              IsActive = game.IsActive,
                              WinPer = sch.WinPer,
                              StartTime = game.StartTime,
                              EndTime = game.EndTime
                          }).ToListAsync();
        }

        public async Task<AllGameViewModel> GetGamebyIdAsync(long gameId)
        {
            return await (from game in context.AllGames
                          join sch in context.SchemeMaster on game.SchemeID equals sch.SchemeID
                          where game.GameId==gameId
                          select new AllGameViewModel
                          {
                              GameId = game.GameId,
                              GameName = game.GameName,
                              SchemeName = sch.SchemeName
                          ,
                              IsActive = game.IsActive,
                              WinPer = sch.WinPer,
                              StartTime = game.StartTime,
                              EndTime = game.EndTime
                          }).FirstOrDefaultAsync();

        }

        public async Task<bool> InsertGameAsync(AllGame allGame)
        {
            await context.AllGames.AddAsync(allGame);
            if (await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateGameAsync(AllGame allGame)
        {
            context.Entry(allGame).Property(ee => ee.GameName).IsModified = true;
            context.Entry(allGame).Property(ee => ee.SchemeID).IsModified = true;
            context.Entry(allGame).Property(ee => ee.StartTime).IsModified = true;
            context.Entry(allGame).Property(ee => ee.EndTime).IsModified = true;
            context.Entry(allGame).Property(ee => ee.IsActive).IsModified = true;
            if (await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
