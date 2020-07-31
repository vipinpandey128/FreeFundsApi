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
    public class UsersConcrete : IUsers
    {

        private readonly DatabaseContext _context;
        public UsersConcrete(DatabaseContext context)
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

        public async Task<UsersViewModel> GetUserDetailsByFilterTypeAsync(string searchData, int filterType)
        {
            var userDM = _context.Users;
            if(filterType==1)
            {
                return await (from user in userDM
                              where user.Contactno == searchData
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
                          where user.UserName == searchData
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

        public async Task<bool> AuthenticateUsersAsync(string username, string password)
        {
            var result = await (from user in _context.Users
                          where user.UserName == username && user.Password == password
                          select user).CountAsync();



            return result > 0 ? true : false;


        }

        public async Task<LoginResponse> GetUserDetailsbyCredentialsAsync(string username)
        {
            try
            {
                var result = await (from user in _context.Users
                    join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                              where user.UserName == username 

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


        public async Task<bool> DeleteUsersAsync(int userId)
        {
            var removeuser = await (from user in _context.Users
                              where user.UserId == userId
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

        public async Task<List<Users>> GetAllUsersAsync()
        {
            var result = await (from user in _context.Users
                          where user.Status == true
                          select user).ToListAsync();

            return result;
        }

        public async Task<Users> GetUsersbyIdAsync(int userId)
        {
            var result = await (from user in _context.Users
                          where user.UserId == userId
                          select user).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> InsertUsersAsync(Users user)
        {
            _context.Users.Add(user);
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

        public async Task<decimal> CheckUserBalanceAsync(int userid)
        {
            return await _context.Users.Where(user => user.UserId == userid).Select(user => user.CurrentBal).FirstOrDefaultAsync();
        }

    }
}
