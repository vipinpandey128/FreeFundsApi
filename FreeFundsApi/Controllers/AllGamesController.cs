using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeFundsApi.Concrete;
using FreeFundsApi.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FreeFundsApi.Interface;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllGamesController : ControllerBase
    {
        private readonly IAllGame _allGame;
        private readonly IMapper _mapper;

        public AllGamesController(IAllGame allGame, IMapper mapper)
        {
            _allGame = allGame;
            _mapper = mapper;
        }

        // GET: api/AllGames
        [HttpGet]
        public async Task<IEnumerable<AllGameViewModel>> GetAllGames()
        {
            try
            {
                return await _allGame.GetAllGamesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/AllGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllGameViewModel>> GetAllGame(long id)
        {
            try
            {
                return await _allGame.GetGamebyIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/AllGames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> PutAllGame(long id, AllGame allGame)
        {
            if (id != allGame.GameId)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            allGame.CreatedBy = 0;
            allGame.CreatedDateTime = DateTime.Now;

            try
            {
                if (await _allGame.UpdateGameAsync(allGame))
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

        // POST: api/AllGames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<HttpResponseMessage> PostAllGame(AllGame allGame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _allGame.CheckExistGameAsync(allGame.GameName))
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
                        allGame.CreatedBy = Convert.ToInt32(userId);
                        allGame.CreatedDateTime = DateTime.Now;

                        //var temprole = _mapper.Map<Role>(roleViewModel);
                        if (await _allGame.InsertGameAsync(allGame))
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
                else
                {
                    var response = new HttpResponseMessage()
                    {

                        StatusCode = HttpStatusCode.BadRequest
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE: api/AllGames/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteAllGame(long id)
        {
            try
            {
                if (await _allGame.DeleteGameAsync(id))
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
