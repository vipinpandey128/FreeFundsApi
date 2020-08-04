using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeFundsApi.Common;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    { 
        private readonly IUserProfile _userProfile;
        private readonly IMapper mapper;
        public UserProfileController(IUserProfile userProfile, IMapper mapper)
        {
            _userProfile = userProfile;
            this.mapper = mapper;
        }

        // GET: api/UserProfile/GetUserTransaction
        [Route("GetUserTransaction")]
        [HttpGet]
        public async Task<IEnumerable<AgentTransactionViewModel>> GetUserTransactions()
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _userProfile.getAllAgentTransaction(userId);
        }

        // GET: api/UserProfile
        [HttpGet]
        public async Task<UsersProfileViewModel> GetAllTransactions()
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            var userProfile = await _userProfile.GetUserByIdAsync(userId);
            var tempUserProfile = mapper.Map<UsersProfileViewModel>(userProfile);
            tempUserProfile.Password = EncryptionLibrary.DecryptText(tempUserProfile.Password);
            return tempUserProfile;
        }

        // PUT: api/UserProfile
        [HttpPut("{userId}")]
        public async Task<HttpResponseMessage> UpdateUserProfile(int userId, [FromBody] UsersProfileViewModel userProfile)
        {

            var oldUserProfile = mapper.Map<Users>(userProfile);
            oldUserProfile.Password = EncryptionLibrary.EncryptText(oldUserProfile.Password);
            if (await _userProfile.UpdateUserProfileAsync(oldUserProfile))
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NoContent
                };
                return response;
            }
            else
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
                return response;
            }
             
        }
    }
}