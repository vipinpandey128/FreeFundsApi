using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FreeFundsApi.ViewModels;
using System.Collections.Generic;

namespace FreeFundsApi.Concrete
{
    public class UserProfileConcrete : IUserProfile
    {
        private readonly DatabaseContext _context;

        public UserProfileConcrete(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Users> GetUserByIdAsync(int userId)
        {
            return await (from user in _context.Users
                                    where user.UserId == userId
                                    select user).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserProfileAsync(Users userProfile)
        {
            _context.Entry(userProfile).Property(x => x.EmailId).IsModified = true;
            _context.Entry(userProfile).Property(x => x.Contactno).IsModified = true;
            _context.Entry(userProfile).Property(x => x.FullName).IsModified = true;
            _context.Entry(userProfile).Property(x => x.Password).IsModified = true;
            _context.Entry(userProfile).Property(x => x.WithDrawalPin).IsModified = true;

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<AgentTransactionViewModel>> getAllAgentTransaction(int agentId)
        {
            return await
                (from user in _context.Users
                 join transaction in _context.AllTransactions on user.UserId equals transaction.UserId
                 join TRTY in _context.TransactionTypes on transaction.TransactionTypeId equals TRTY.TransationTypeId
                 where transaction.CreatedBy == agentId
                 select new AgentTransactionViewModel
                 {
                     TransactionAmount = transaction.TransactionAmount,
                     BetAmount = 0,
                     BetNumber = 0,
                     DateTime = transaction.CreatedDate,
                     GameName = "",
                     SchemeName = "",
                     TransactionTypeName = TRTY.TransactionTypeName,
                     Username = user.UserName,
                     WinPer = 0
                 }).ToListAsync();
        }
    }
}
