using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreeFundsApi.Interface;
using FreeFundsApi.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenerateRecepitController : ControllerBase
    {
        private readonly IGenerateRecepit _generateRecepit;
        public GenerateRecepitController(IGenerateRecepit generateRecepit)
        {
            _generateRecepit = generateRecepit;
        }
       

        // POST: api/GenerateRecepit
        [HttpPost]
        public GenerateRecepitViewModel Post([FromBody] GenerateRecepitRequestModel generateRecepitRequestModel)
        {
            try
            {
                return _generateRecepit.Generate(generateRecepitRequestModel.PaymentId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
