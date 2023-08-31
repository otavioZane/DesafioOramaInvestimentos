using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Data.Db.Service;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using System.Security.Principal;

namespace OramaInvestimentos.Controller {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankAccountController : GenericController {

        public BankAccountController(ILogger _logger, IUserService _userService, IBankAccountService _bankAccountService, IAssetMaintenanceService _assetMaintenanceService) 
            : base(_logger, _userService, _bankAccountService, _assetMaintenanceService)
        {
            
        }

        [HttpGet("getstatement")]
        [SwaggerOperation("GetStatement")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful GetStatement")]
        public ActionResult GetStatement() {
            try {
                var request = new Request.GetStatement() {
                    customerID = Identity()
                };
                _logger.LogInformation("Request GetStatement: {@Request}", request);
                var response = _bankAccountService.GetStatement(request);
                _logger.LogInformation("Response Signin: {@Response}", response);

                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError Signup: {@Error}", err);
                return StatusCode((int)(int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error Signin: {@Error}", err);
                return StatusCode(500, err);
            }
        }

        [HttpGet("getbalance")]
        [SwaggerOperation("GetBalance")] 
        [SwaggerResponse(StatusCodes.Status200OK, "Successful GetBalance")]
        public ActionResult GetBalanceInquiry() {
            try {
                var request = new Request.GetBalance() {
                    customerID = Identity()
                };
                _logger.LogInformation("Request GetBalance: {@Request}", request);
                var response = _bankAccountService.GetBalance(request);
                _logger.LogInformation("Response GetBalance: {@Response}", response);          
                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError GetBalance: {@Error}", err);
                return StatusCode((int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error GetBalance: {@Error}", err);
                return StatusCode(500, err);
            }
        }
    }
}
