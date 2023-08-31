using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Data.Db.Service;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using System.Security.Principal;

namespace OramaInvestimentos.Controller {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssetMaintenaceController : GenericController{

        public AssetMaintenaceController(ILogger _logger, IUserService _userService, IBankAccountService _bankAccountService, IAssetMaintenanceService _assetMaintenanceService)
            : base(_logger, _userService, _bankAccountService, _assetMaintenanceService) {

        }

        [HttpGet("getfinancialassets")]
        [SwaggerOperation("GetFinancialAssets")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful GetFinancialAssets")]
        public ActionResult GetFinancialAssets() {
            try {             
                _logger.LogInformation("Request GetFinancialAssets");
                var response = _assetMaintenanceService.GetFinancialAssets();
                _logger.LogInformation("Response GetFinancialAssets: {@Response}", response);

                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError GetFinancialAssets: {@Error}", err);
                return StatusCode((int)(int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error GetFinancialAssets: {@Error}", err);
                return StatusCode(500, err);
            }
        }

        [HttpPost("buyfinancialasset")]
        [SwaggerOperation("BuyFinancialAsset")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful BuyFinancialAsset")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad BuyFinancialAsset")]
        public ActionResult BuyAsset(
            [FromBody] Request.BuyFinancialAsset request
        ) {
            try {
                _logger.LogInformation("Request BuyFinancialAsset - {@Customer} : {@Request}",  Identity(), request);
                var response = _assetMaintenanceService.BuyFinancialAsset(request, Identity());
                _logger.LogInformation("Response BuyFinancialAsset: {@Response}", response);

                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError BuyAsset: {@Error}", err);
                return StatusCode((int)(int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error BuyAsset: {@Error}", err);
                return StatusCode(500, err);
            }
        }

        [HttpPost("sellfinancialasset")]
        [SwaggerOperation("SellFinancialAsset")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful SellFinancialAsset")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad SellFinancialAsset")]
        public ActionResult SellAsset(
            [FromBody] Request.BuyFinancialAsset request
        ) {
            try {
                _logger.LogInformation("Request SellFinancialAsset - {@Customer} : {@Request}", Identity(), request);
                var response = _assetMaintenanceService.SellFinancialAsset(request, Identity());
                _logger.LogInformation("Response SellFinancialAsset: {@Response}", response);

                return Ok(response);
            }
            catch (CustomError err) {
                _logger.LogError("Exception CustomError SellFinancialAsset: {@Error}", err);
                return StatusCode((int)(int)err.status, err.error);
            }
            catch (Exception err) {
                _logger.LogError("Exception error SellFinancialAsset: {@Error}", err);
                return StatusCode(500, err);
            }
        }

    }
}
