using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Interfaces;

namespace BalanceQueryMaintenance.API.Controllers {


    [ApiController]
    [Route("api/v1/user")]
    public class BalanceQueryMaintenanceController : ControllerBase {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public BalanceQueryMaintenanceController(ILogger logger, IUserService userService) {
            _logger = logger;
            _userService = userService;
        }
    }


}
