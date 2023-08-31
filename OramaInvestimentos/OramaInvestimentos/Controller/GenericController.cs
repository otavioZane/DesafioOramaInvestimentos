using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Interfaces;
using System.Security.Claims;

namespace OramaInvestimentos.Controller {
    public class GenericController : ControllerBase {

        protected ILogger _logger;
        protected readonly IUserService _userService;
        protected readonly IBankAccountService _bankAccountService;
        protected readonly IAssetMaintenanceService _assetMaintenanceService;

        public GenericController(ILogger logger, IUserService userService, IBankAccountService bankAccountService, IAssetMaintenanceService assetMaintenanceService) {
            _logger = logger;
            _userService = userService;
            _bankAccountService = bankAccountService;
            _assetMaintenanceService = assetMaintenanceService;
        }

        protected int Identity() {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var idClaim = claim.Where(x => x.Type == "customerID").FirstOrDefault();
            var customerId = int.Parse(idClaim.Value.ToString());

            return customerId;
        }


    }
}
