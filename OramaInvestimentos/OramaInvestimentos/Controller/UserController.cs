using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace OramaInvestimentos.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController {

        public UserController(ILogger _logger, IUserService _userService, IBankAccountService _bankAccountService, IAssetMaintenanceService _assetMaintenanceService)
            : base(_logger, _userService, _bankAccountService, _assetMaintenanceService) {

        }

        [HttpPost("signin")]
        [SwaggerOperation("Signin")] 
        [SwaggerResponse(StatusCodes.Status200OK, "Successful signin", typeof(Entities.Response.Signin))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public ActionResult<Entities.Response.Signin> Signin(
            [FromBody] Entities.Request.Signin request
        ) {
            try {
                _logger.LogInformation("Request Signin: {@Request}", request);
                var response = _userService.Signin(request);
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

        [HttpPost("signup")]
        [SwaggerOperation("Signup")] 
        [SwaggerResponse(StatusCodes.Status200OK, "Successful signup", typeof(Entities.Response.Signup))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public ActionResult<Entities.Response.Signup> Signup(
            [FromBody] Entities.Request.Signup request
        ) {
            try {
                _logger.LogInformation("Request Signup: {@Request}", request);
                var response = _userService.Signup(request);
                _logger.LogInformation("Response Signup: {@Response}", response);          
                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError Signup: {@Error}", err);
                return StatusCode((int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error Signup: {@Error}", err);
                return StatusCode(500, err);
            }
        }
    }
}
