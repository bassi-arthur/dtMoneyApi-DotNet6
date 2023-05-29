using dtMoneyApi.Data;
using dtMoneyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dtMoneyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsControler : ControllerBase
    {

        private readonly DataContext _context;

        public TransactionsControler(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetById(int id)
        {
            var transaction = _context.Transactions.FindAsync(id);

            if (transaction.Result == null)
                return BadRequest("Transaction not found.");

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok(_context.Transactions);
        }


        [HttpPut]
        public async Task<ActionResult<List<Transaction>>> UpdateTransaction(Transaction request)
        {
            var transaction = await _context.Transactions.FindAsync(request.Id);

            if (transaction == null)
                return BadRequest("Transaction not found.");

            transaction.Id = request.Id;
            transaction.Quantity = request.Quantity;
            transaction.Title = request.Title;
            transaction.Type = request.Type;

            await _context.SaveChangesAsync();

            return Ok(transaction);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteById(int id)
        {
            var transaction = _context.Transactions.FindAsync(id);

            if (transaction.Result == null)
                return BadRequest("Transaction not found.");

            _context.Transactions.Remove(transaction.Result);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
