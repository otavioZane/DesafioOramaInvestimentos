using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Entities;

namespace StatementQueryMaintenance.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StatementQueryController : ControllerBase {
        [ApiController]
        [Route("api/[controller]")]
        public class FinancialAssetsController : ControllerBase {
            private readonly DbContext _context;

            public FinancialAssetsController(DbContext context) {
                _context = context;
            }

            //    [HttpGet]
            //    public async Task<ActionResult<IEnumerable<FinancialAsset>>> GetFinancialAssets() {
            //        return await _context.FinancialAssets.ToListAsync();
            //    }

            //    [HttpGet("{id}")]
            //    public async Task<ActionResult<FinancialAsset>> GetFinancialAsset(int id) {
            //        var asset = await _context.FinancialAssets.FindAsync(id);

            //        if (asset == null) {
            //            return NotFound();
            //        }

            //        return asset;
            //    }

            //    [HttpPost]
            //    public async Task<ActionResult<FinancialAsset>> CreateFinancialAsset(FinancialAsset asset) {
            //        _context.FinancialAssets.Add(asset);
            //        await _context.SaveChangesAsync();

            //        return CreatedAtAction(nameof(GetFinancialAsset), new { id = asset.AssetID }, asset);
            //    }

            //    [HttpPut("{id}")]
            //    public async Task<IActionResult> UpdateFinancialAsset(int id, FinancialAsset asset) {
            //        if (id != asset.AssetID) {
            //            return BadRequest();
            //        }

            //        _context.Entry(asset).State = EntityState.Modified;

            //        try {
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException) {
            //            if (!FinancialAssetExists(id)) {
            //                return NotFound();
            //            }
            //            else {
            //                throw;
            //            }
            //        }

            //        return NoContent();
            //    }

            //    [HttpDelete("{id}")]
            //    public async Task<IActionResult> DeleteFinancialAsset(int id) {
            //        var asset = await _context.FinancialAssets.FindAsync(id);

            //        if (asset == null) {
            //            return NotFound();
            //        }

            //        _context.FinancialAssets.Remove(asset);
            //        await _context.SaveChangesAsync();

            //        return NoContent();
            //    }

            //    private bool FinancialAssetExists(int id) {
            //        return _context.FinancialAssets.Any(a => a.AssetID == id);
            //    }
            //}
        }
    }
}
