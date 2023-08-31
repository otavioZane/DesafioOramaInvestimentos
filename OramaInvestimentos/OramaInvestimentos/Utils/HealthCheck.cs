using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace OramaInvestimentos.Utils {

    public class HealthCheck : IHealthCheck {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken)) {
            return Task.FromResult(HealthCheckResult.Healthy("UP"));
        }
    }
}

