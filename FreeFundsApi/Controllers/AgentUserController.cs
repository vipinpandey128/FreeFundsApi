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
    public class AgentUserController : ControllerBase
    {
        private readonly IAgent _users;
        private readonly IMapper mapper;
        public AgentUserController(IAgent users, IMapper mapper)
        {
            _users = users;
            this.mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _users.GetAllUsersAsync(userId);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetAgentUsers")]
        public async Task<Users> Get(int id)
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _users.GetUsersbyIdAsync(id, userId);
        }

        [HttpGet]
        [Route("getAgentBal")]
        public async Task<decimal> GetAgentBal()
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _users.CheckAgentBalanceAsync(userId);
        }

        // GET: api/AgentUser/searchData/filterType
        [HttpGet("{searchData}/{filterType}", Name = "FilterAgentUser")]
        public async Task<UsersViewModel> GetAgentUserDetails([FromRoute] string searchData, [FromRoute] int filterType)
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return await _users.GetAgentUserDetailsByFilterTypeAsync(searchData, filterType, userId);
        }

        // POST: api/AgentUser
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] UsersViewModel users)
        {
            if (ModelState.IsValid)
            {
                if (await _users.CheckUsersExitsAsync(users.UserName))
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Conflict
                    };

                    return response;
                }
                else
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.Name);
                    var tempUsers = mapper.Map<Users>(users);
                    tempUsers.CreatedDate = DateTime.Now;
                    tempUsers.Createdby = Convert.ToInt32(userId);
                    tempUsers.Password = EncryptionLibrary.EncryptText(users.Password);
                    tempUsers.Status = true;
                    await _users.InsertUsersAsync(tempUsers);

                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                    return response;
                }
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

        // PUT: api/AgentUser/5
        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] UsersViewModel users)
        {
            if (ModelState.IsValid)
            {

                var tempUsers = mapper.Map<Users>(users);
                tempUsers.CreatedDate = DateTime.Now;
                await _users.UpdateUsersAsync(tempUsers);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            var result = await _users.DeleteUsersAsync(id, userId);

            if (result)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
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