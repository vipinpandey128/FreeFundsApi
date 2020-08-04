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
using System.Net.Http;
using FreeFundsApi.Interface;
using System.Net;
using FreeFundsApi.ViewModels;
using System.Security.Claims;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllTransactionsController : ControllerBase
    {
        private readonly IAllTransaction _allTransaction;
        private readonly IUsers _user;
        private readonly IMapper mapper;

        public AllTransactionsController(IAllTransaction allTransaction, IUsers user, IMapper mapper)
        {
            _allTransaction = allTransaction;
            _user = user;
            this.mapper = mapper;
        }

        // GET: api/AllTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllTransaction>>> GetAllTransactions()
        {
            return await _allTransaction.GetTransactionsAsync();
        }

        // GET: api/AllTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllTransaction>> GetAllTransaction(long id)
        {
            return null;
        }


        // POST: api/AllTransactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<HttpResponseMessage> PostAllTransaction([FromBody] TransactionViewModel allTransaction)
        {
            try
            {
                if (!await _user.ValidateUserByPin(allTransaction.UserId, allTransaction.pin))
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Unauthorized
                    };
                }

                   var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));

                    var userCurrentBal = await _user.CheckUserBalanceAsync(allTransaction.TransactionTypeId==3?allTransaction.UserId:userId);
                    var tempTransaction = mapper.Map<AllTransaction>(allTransaction);
                    if (userCurrentBal >= allTransaction.TransactionAmount)
                    {
                        tempTransaction.CreatedBy = Convert.ToInt32(userId);
                        tempTransaction.CreatedDate = DateTime.Now;
                        tempTransaction.RecordId = 0;
                        tempTransaction.IsActive = true;
                        long transactionIDAgent = await _allTransaction.InsertTransactionAsync(tempTransaction);
                        if (transactionIDAgent > 0)
                        {
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.OK
                            };
                        }
                        else
                        {
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.InternalServerError
                            };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest
                        };
                    }
                 
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
