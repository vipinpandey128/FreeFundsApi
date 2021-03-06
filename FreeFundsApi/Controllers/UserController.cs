﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreeFundsApi.Common;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using AutoMapper;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly IMapper mapper;
        public UserController(IUsers users, IMapper mapper)
        {
            _users = users;
            this.mapper = mapper;
        }
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            return await _users.GetAllUsersAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        public async Task<Users> Get(int id)
        {
            return await _users.GetUsersbyIdAsync(id);
        }

        // GET: api/User/searchData/filterType
        [HttpGet("{searchData}/{filterType}", Name = "FilterUser")]
        public async Task<UsersViewModel> GetUserDetails([FromRoute] string searchData, [FromRoute] int filterType)
        {
            return await _users.GetUserDetailsByFilterTypeAsync(searchData, filterType);
        }
         

        // POST: api/User
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

        // PUT: api/User/5
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
            var result = await _users.DeleteUsersAsync(id);

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
