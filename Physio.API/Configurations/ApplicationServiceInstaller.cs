using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Physio.Application;
using Physio.Application.Authenticate.Commands.Login;
namespace Physio.API.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(option => option.LowercaseUrls = true);
        services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);
        services.AddEndpointsApiExplorer();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(AssemblyReference));
            //cfg.RegisterServicesFromAssemblyContaining<AuthenticateCommand>();
        });

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Physio API", Version = "1.0" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Entre com o Token JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                }
            });
        });

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //services.AddValidatorsFromAssembly(
        //    Application.AssemblyReference.Assembly,
        //    includeInternalTypes: true);
    }
}