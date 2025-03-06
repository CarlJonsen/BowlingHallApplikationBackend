using DatabaseModule.Models;
using MatchAPI.ModelsDto;
using MatchAPI.Repository;
using MatchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAccount([FromBody] AccountDto accountDto)
        {
            try
            {
                var newAccount = _accountService.CreateNewAccount(accountDto.Username , accountDto.Password);
                return Ok(newAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LogInAccount([FromBody] AccountDto accountDto)
        {
            try
            {
                var account = _accountService.LogInAccount(accountDto.Username, accountDto.Password);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("matchHistory")]
        public IActionResult GetMatchHistory(int accountId)
        {
            try
            {
                var matchHistory = _accountService.GetMatchHistoryByAccountId(accountId);

                if (matchHistory.Count > 0)
                {
                    return Ok(matchHistory);
                }

                return NotFound("Ingen matchhistorik hittades för angivet konto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
