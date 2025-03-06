using MatchAPI.ModelsDto;
using MatchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchAPI.Controllers
{
    public class MatchController : Controller
    {
        private readonly  MatchService _matchService;
        public MatchController(MatchService matchService) 
        {
            _matchService = matchService;
        }


        [HttpPost]
        [Route("CreateMatch")]
        public async Task<IActionResult> CreateMatchAsync([FromBody] CreateMatchDto request)
        {
            var result = await _matchService.CreateMatchAsync(
                request.MatchName,
                request.AccountId,
                request.BookingSlotId,
                request.PlayerNames
            );

            if (result == null)
            {
                return BadRequest("Kunde inte skapa matchen. Kontrollera inmatade värden.");
            }

            return Ok(result);
        }
    }
}
