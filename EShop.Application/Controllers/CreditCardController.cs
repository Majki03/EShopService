using Microsoft.AspNetCore.Mvc;
using EShop.Domain.Services;
using EShop.Domain.Enums;
using EShop.Domain.Exceptions;
using EShop.Application.Models;

namespace EShop.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult ValidateCard([FromBody] CreditCardCheckRequest request)
        {
            try
            {
                var provider = CreditCardValidator.Validate(request.CardNumber);

                return Ok(new
                {
                    Status = "Valid",
                    Provider = provider.ToString()
                });
            }
            catch (CardNumberTooLongException ex)
            {
                return StatusCode(414, new { Error = ex.Message });
            }
            catch (CardNumberTooShortException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (CardNumberInvalidException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (UnsupportedCardProviderException ex)
            {
                return StatusCode(406, new { Error = ex.Message });
            }
        }
    }
}