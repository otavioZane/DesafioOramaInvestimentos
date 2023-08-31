using OramaInvestimentos.Utils;

namespace OramaInvestimentos.Data.Db.Service {
    public static class  HealthCheckService {

        public static IServiceCollection AddHealthChecksInjection(this IServiceCollection services) {
            services.AddHealthChecks()
                .AddCheck<HealthCheck>("Healthy");
            return services;
        }
    }

}

