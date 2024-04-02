
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Authentication;
using Physio.Infrasctructure.Context;
using Physio.Infrasctructure.Repositories;
using Physio.Infrastructure.Repositories;

namespace Physio.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
    {
        ConfiguringIdentityServer(services);
        AddContext(services, configurationManager);
       
        //AddBlobService(services, configurationManager);
        AddRepositories(services);
    }

    private static void AddBlobService(IServiceCollection services, IConfiguration configurationManager)
    {
        //services.AddAzureClients(builder =>
        //{
        //    builder.AddBlobServiceClient(configurationManager.GetConnectionString("Blobstorage"));
        //    //builder.AddQueueServiceClient(storageConnectionString)
        //    //.ConfigureOptions(c =>
        //    //{
        //    //    c.MessageEncoding = QueueMessageEncoding.Base64;
        //    //});
        //    //builder.AddTableServiceClient(storageConnectionString);
        //});
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddDbContext<PhysioContext>(dbContext =>
        {
            dbContext.UseSqlServer(configurationManager.GetConnectionString("Database"));
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IContactRepository, ContactRepository>()
                .AddScoped<IClinicRepository, ClinicRepository>()
                .AddScoped<IClinicPatientRepository, ClinicPatientRepository>()
                .AddScoped<IClinicSchedulingRepository, ClinicSchedulingRepository>()
                
                .AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IClinicProfessionalRepository, ClinicProfessionalRepository>()
                .AddScoped<IMedicalAppointmentRepository, MedicalAppointmentRepository>()
                .AddScoped<IProfessionalRepository, ProfessionalRepository>()

                .AddScoped<IProfessionalPatientRepository, ProfessionalPatientRepository>()

                .AddScoped<IProtocolRepository, ProtocolRepository>()
                .AddScoped<IStatusSchedulingRepository, StatusSchedulingRepository>()
                .AddScoped<ISchedulingTypeRepository, SchedulingTypeRepository>()
                .AddScoped<ISchedulingRepository, SchedulingRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void ConfiguringIdentityServer(IServiceCollection services)
    {
        services.AddIdentity<UserEntity, IdentityRole>()
              .AddEntityFrameworkStores<PhysioContext>();

        services.Configure<IdentityOptions>(options => {
            options.User.RequireUniqueEmail = true;
        });

    }
}