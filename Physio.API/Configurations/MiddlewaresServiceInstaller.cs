
using Physio.API.Middlewares;

namespace Physio.API.Configurations;

public class MiddlewaresServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
        services.AddTransient<UserIdentificationMiddleware>();
    }
}
