using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CreateRoleController : ControllerBase
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public CreateRoleController(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        // GET: api/CreateRole
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            try
            {
                return _role.GetAllRole();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/CreateRole/5
        [HttpGet("{id}", Name = "GetRole")]
        public Role Get(int id)
        {
            try
            {
                return _role.GetRolebyId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/CreateRole
        [HttpPost]
        public HttpResponseMessage Post([FromBody] RoleViewModel roleViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (_role.CheckRoleExits(roleViewModel.RoleName))
                    {
                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.Conflict
                        };

                        return response;
                    }
                    else
                    {
                        //var temprole = _mapper.Map<Role>(roleViewModel);
                        var temprole = new Role
                        {
                            RoleName = roleViewModel.RoleName,
                            Status = roleViewModel.Status
                        };

                        _role.InsertRole(temprole);

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
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/CreateRole/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] RoleViewModel roleViewModel)
        {
            try
            {
                //var temprole = _mapper.Map<Role>(roleViewModel);
                var temprole = new Role
                {
                    RoleName = roleViewModel.RoleName,
                    Status = roleViewModel.Status,
                    RoleId = id
                };
                _role.UpdateRole(temprole);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
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
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                var result = _role.DeleteRole(id);

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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
