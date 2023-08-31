using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OramaInvestimentos.Data.Db.Client;
using OramaInvestimentos.Data.Db.Repository;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using OramaInvestimentos.Utils;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using OramaInvestimentos.Data.Db.Service;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<FinancialDbContext>(options => {
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtConfig:Issuer"],
                    ValidAudience = configuration["JwtConfig:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:RsaPrivateKey"]))
                };
            });

builder.Services
                .AddControllers()
                .AddNewtonsoftJson(
                    options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                            .Json
                            .ReferenceLoopHandling
                            .Ignore
                );

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    options => {
        options.EnableAnnotations();
        options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "OramaInvestimentos" });
        options.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme {
                In = ParameterLocation.Header,
                Description = "Digite o token retornado pela api de signin",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            }
        );
        options.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
            }
        );
        options.CustomSchemaIds(type => type.FullName);
    });

// Logger

var logger = builder.Services.AddLogging().BuildServiceProvider().GetService<ILoggerFactory>().CreateLogger<Program>();

//builder.Services.AddLogger(Configuration);

builder.Services.AddHealthChecks()
                .AddCheck<HealthCheck>("Healthy");

builder.Services.AddSingleton<ILogger>(logger);

builder.Services.AddSingleton(
                configuration.GetSection(typeof(JwtConfig).Name).Get<JwtConfig>()
            );
builder.Services.AddSingleton(configuration.GetSection(typeof(Keys).Name).Get<Keys>());

builder.Services.AddTransient<ISalt, Salt>();

builder.Services.AddTransient<IValidation, Validation>();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IBankAccountRepository, BankAccountRepository>();

builder.Services.AddTransient<IBankAccountService, BankAccountService>();

builder.Services.AddTransient<IAssetMaintenanceRepository, AssetMaintenanceRepository>();

builder.Services.AddTransient<IAssetMaintenanceService, AssetMaintenanceService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHealthChecks(
                    "/health",
                    new HealthCheckOptions() {
                        ResponseWriter = (HttpContext, result) => {
                            HttpContext.Response.ContentType = "application/json";

                            var json = new JObject(
                                result.Entries.Select(
                                    health => new JProperty("status", health.Value.Description)
                                )
                            );
                            return HttpContext.Response.WriteAsync(
                                json.ToString(Formatting.Indented)
                            );
                        }
                    }
                );
});

app.MapControllers();

app.Run();
