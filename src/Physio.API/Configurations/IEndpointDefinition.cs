namespace Physio.API.Configurations
{
    public interface IEndpointDefinition
    {
        void RegisterEndpoints(WebApplication app);
    }
}
