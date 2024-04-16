using Balance.App.Data;
using Microsoft.AspNetCore.Mvc;

namespace Balance.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalancesController : ControllerBase
    {
        private readonly BalanceDbContext _context;
        private readonly ILogger<BalancesController> _logger;

        public BalancesController(ILogger<BalancesController> logger, BalanceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{account_id}")]
        public IActionResult Get(Guid account_id)
        {
            var balance = _context.Accounts.FirstOrDefault(b => b.Id == account_id);
            if (balance == null)
            {
                return NotFound(); 
            }

            return Ok(balance);
        }
    }
}
