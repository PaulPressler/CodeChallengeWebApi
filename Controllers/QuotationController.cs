using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallengeAPI
{
    [EnableCors("CorsPolicy")]
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateQuote(QuoteRequest quoteRequest)
        {
            try {
                return Ok(await _quotationService.CalculateQuote(quoteRequest));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}