using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OramaInvestimentos.Interfaces {
    public interface IHealthCheck {
            Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default);
        }
}
