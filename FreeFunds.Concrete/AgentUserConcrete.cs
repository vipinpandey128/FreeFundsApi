using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FreeFundsApi.Concrete
{
    public class AgentUserConcrete : IAgent
    {

        private readonly DatabaseContext _context;
        public AgentUserConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUsersExitsAsync(string username)
        {
            var result = await (from user in _context.Users
                                where user.UserName == username
                                select user).CountAsync();

            return result > 0 ? true : false;
        }


        public async Task<UsersViewModel> GetAgentUserDetailsByFilterTypeAsync(string searchData, int filterType, int loginId)
        {
            var userDM = _context.Users;
            if (filterType == 1)
            {
                return await (from user in userDM
                              join userRole in _context.UsersInRoles on user.UserId equals userRole.UserId
                              join role in _context.Role on userRole.RoleId equals role.RoleId
                              where user.Contactno == searchData && role.RoleName == "User" && user.Createdby== loginId
                              select new UsersViewModel
                              {
                                  Contactno = user.Contactno,
                                  CurrentBal = user.CurrentBal,
                                  FullName = user.FullName,
                                  Id = user.UserId,
                                  Password = "",
                                  Status = user.Status,
                                  UserName = user.UserName
                              }).FirstOrDefaultAsync();
            }

            return await (from user in userDM
                          join userRole in _context.UsersInRoles on user.UserId equals userRole.UserId
                          join role in _context.Role on userRole.RoleId equals role.RoleId
                          where user.UserName == searchData && role.RoleName == "User" && user.Createdby == loginId
                          select new UsersViewModel
                          {
                              Contactno = user.Contactno,
                              CurrentBal = user.CurrentBal,
                              FullName = user.FullName,
                              Id = user.UserId,
                              Password = "",
                              Status = user.Status,
                              UserName = user.UserName
                          }).FirstOrDefaultAsync();
        }

        public async Task<LoginResponse> GetUserDetailsbyCredentialsAsync(string username, int loginId)
        {
            try
            {
                var result = await (from user in _context.Users
                                    join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                                    where user.UserName == username && userinrole.RoleId== 3 && user.Createdby == loginId

                                    select new LoginResponse
                                    {
                                        UserId = user.UserId,
                                        RoleId = userinrole.RoleId,
                                        Status = user.Status,
                                        UserName = user.UserName
                                    }).SingleOrDefaultAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> DeleteUsersAsync(int userId, int loginId)
        {
            var removeuser = await (from user in _context.Users
                                    join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                                    where user.UserId == userId && userinrole.RoleId == 3 && user.Createdby == loginId
                                    select user).FirstOrDefaultAsync();
            if (removeuser != null)
            {
                _context.Users.Remove(removeuser);
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
            else
            {
                return false;
            }
        }

        public async Task<List<Users>> GetAllUsersAsync(int loginId)
        {
            var result = await (from user in _context.Users
                                join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                                where user.Status == true && userinrole.RoleId == 3 && user.Createdby== loginId
                                select user).ToListAsync();

            return result;
        }

        public async Task<Users> GetUsersbyIdAsync(int userId, int loginId)
        {
            var result = await (from user in _context.Users
                                join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                                where user.UserId == userId && userinrole.RoleId == 3 && user.Createdby== loginId
                                select user).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> InsertUsersAsync(Users user)
        {
            using (var DBtransaction = _context.Database.BeginTransaction())
            {
                try
                {

                    _context.Users.Add(user);
                    var UserId = await _context.SaveChangesAsync();
                    if (UserId > 0)
                    {
                        _context.UsersInRoles.Add(new UsersInRoles { RoleId = 3, UserId = user.UserId });
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            await DBtransaction.CommitAsync();
                            return true;
                        }
                        await DBtransaction.RollbackAsync();
                        return false;
                    }
                    else
                    {
                        await DBtransaction.RollbackAsync();
                        return false;
                    }
                }
                catch (Exception)
                {
                    await DBtransaction.RollbackAsync();
                    throw;
                }
            }

        }


        public async Task<bool> UpdateUsersAsync(Users user)
        {
            _context.Entry(user).Property(x => x.EmailId).IsModified = true;
            _context.Entry(user).Property(x => x.Contactno).IsModified = true;
            _context.Entry(user).Property(x => x.Status).IsModified = true;
            _context.Entry(user).Property(x => x.FullName).IsModified = true;
            _context.Entry(user).Property(x => x.Password).IsModified = true;

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

        public async Task<decimal> CheckUserBalanceAsync(int userid,int loginId)
        {
            return await _context.Users.Where(user => user.UserId == userid && user.Createdby== loginId).Select(user => user.CurrentBal).FirstOrDefaultAsync();
        }

    }
}
