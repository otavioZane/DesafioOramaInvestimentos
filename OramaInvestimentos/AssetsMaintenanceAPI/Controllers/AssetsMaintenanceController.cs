using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Interfaces;
using System.Collections.Generic;

namespace AssetsMaintenance.API.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class AssetMaintenanceController : ControllerBase {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public AssetMaintenanceController(ILogger logger, IUserService userService) {
            _logger = logger;
            _userService = userService;
        }

       
    }
    }
