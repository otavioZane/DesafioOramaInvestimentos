namespace OramaInvestimentos.Utils {
    public static class LoggingServiceCollectionExtension {
        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration) {
            var logger = services.AddLogging()
                      .BuildServiceProvider().GetService<ILoggerFactory>().CreateLogger<Program>();
            services.AddSingleton<ILogger>(logger);
            return services;
        }
    }
}
