using Invoicing.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Invoicing.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IBusinessData _data;

        public DashboardController(ILogger<DashboardController> logger, IBusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet("{value}")]
        public ActionResult<decimal> GetData(string value)
        {
            if (value == "ca")
            {
                decimal ca = _data.AllInvoices.Sum(invoice => invoice.Amount);
                return ca;
            }
            else if (value == "aPayer")
            {
                decimal aPayer = _data.AllInvoices.Sum(invoice => invoice.Amount - invoice.Paid);
                return aPayer;
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
      
    }
}
