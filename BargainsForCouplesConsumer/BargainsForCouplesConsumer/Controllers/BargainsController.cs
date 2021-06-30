using System.Threading.Tasks;
using BargainsForCouplesConsumer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BargainsForCouplesConsumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BargainsController : ControllerBase
    {
        private readonly ILogger<BargainsController> _logger;
        private readonly IConsumerService _consumerService;

        public BargainsController(ILogger<BargainsController> logger, IConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> FindBargains([FromBody] params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                return BadRequest("Only two (2) parameters are allowed: destinationId and nights");
            }

            var destinationIdParse = int.TryParse(parameters[0], out var destinationId);
            var numberOfNightsParse = int.TryParse(parameters[1], out var numberOfNights);

            if (!destinationIdParse || !numberOfNightsParse)
            {
                return BadRequest(
                    "One or both of the parameters are in an invalid format - both must be numbers");
            }

            var bargains = await _consumerService.GetBargains(destinationId, numberOfNights);
            return Ok(bargains);
        }
    }
}
