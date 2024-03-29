﻿using Physio.Infrastructure;
//using Scrutor;

namespace Physio.API.Configurations;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        //services
        //      .Scan(
        //          selector => selector
        //              .FromAssemblies(
        //                 Infrastructure.AssemblyReference.Assembly)
        //              .AddClasses(false)
        //              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //              .AsMatchingInterface()
        //              .WithScopedLifetime());

        services.AddInfrastructure(configuration);
    }
}
