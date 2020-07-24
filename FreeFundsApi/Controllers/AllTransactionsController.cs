using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeFundsApi.Concrete;
using FreeFundsApi.Models;

namespace FreeFundsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllTransactionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AllTransactionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AllTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllTransaction>>> GetAllTransactions()
        {
            return await _context.AllTransactions.ToListAsync();
        }

        // GET: api/AllTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllTransaction>> GetAllTransaction(long id)
        {
            var allTransaction = await _context.AllTransactions.FindAsync(id);

            if (allTransaction == null)
            {
                return NotFound();
            }

            return allTransaction;
        }

        // PUT: api/AllTransactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllTransaction(long id, AllTransaction allTransaction)
        {
            if (id != allTransaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(allTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AllTransactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AllTransaction>> PostAllTransaction(AllTransaction allTransaction)
        {
            _context.AllTransactions.Add(allTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllTransaction", new { id = allTransaction.TransactionId }, allTransaction);
        }

        // DELETE: api/AllTransactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllTransaction>> DeleteAllTransaction(long id)
        {
            var allTransaction = await _context.AllTransactions.FindAsync(id);
            if (allTransaction == null)
            {
                return NotFound();
            }

            _context.AllTransactions.Remove(allTransaction);
            await _context.SaveChangesAsync();

            return allTransaction;
        }

        private bool AllTransactionExists(long id)
        {
            return _context.AllTransactions.Any(e => e.TransactionId == id);
        }
    }
}
