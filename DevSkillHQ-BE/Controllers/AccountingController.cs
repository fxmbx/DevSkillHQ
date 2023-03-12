using DevSkillHQ_BE.CustomException;
using DevSkillHQ_BE.Dto;
using DevSkillHQ_BE.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevSkillHQ_BE.Controllers
{
    [ApiController]
    public class AccountingController : ControllerBase
    {

        private readonly IAccountingService _iaccountingService;

        public AccountingController(IAccountingService _iaccountingService)
        {
            this._iaccountingService = _iaccountingService;
        }
        [HttpGet("/ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpPost("/transactions")]
        public IActionResult CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = this._iaccountingService.CreateTransaction(createTransactionDto);
                return Ok(response);
            }
            catch (ReuseableCustomException ex)
            {
                return new CustomActionResult((System.Net.HttpStatusCode)ex.GetStatusCode(), ex.Message);
            }
            catch (Exception ex)
            {
                return new CustomActionResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet("/transactions")]
        public IActionResult GetTransactions()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = this._iaccountingService.GetTransactions();
                return Ok(response);
            }
            catch (ReuseableCustomException ex)
            {
                return new CustomActionResult((System.Net.HttpStatusCode)ex.GetStatusCode(), ex.Message);
            }
            catch (Exception ex)
            {
                return new CustomActionResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost("/transactions/{transaction_id}")]
        public IActionResult GetTransactionByID([FromRoute] string transaction_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = this._iaccountingService.GetTransactionByID(transaction_id);
                return Ok(response);
            }
            catch (ReuseableCustomException ex)
            {
                return new CustomActionResult((System.Net.HttpStatusCode)ex.GetStatusCode(), ex.Message);
            }
            catch (Exception ex)
            {
                return new CustomActionResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet("/accounts/{account_id}")]
        public IActionResult GetAccountDetail([FromRoute] string account_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = this._iaccountingService.GetAccount(account_id);
                return Ok(response);
            }
            catch (ReuseableCustomException ex)
            {
                return new CustomActionResult((System.Net.HttpStatusCode)ex.GetStatusCode(), ex.Message);
            }
            catch (Exception ex)
            {
                return new CustomActionResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
