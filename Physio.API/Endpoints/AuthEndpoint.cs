using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Authenticate.Commands.Login;
using Physio.Application.Authenticate.Commands.Register;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.API.Endpoints
{
    public class AuthEndpoint : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var routes = app.MapGroup("api/auth");

            routes.MapPost("/register", Register)
            .Produces<AuthenticationResponse>(200)
            .AddEndpointFilter<ValidationFilter<RegisterRequest>>()
            .AllowAnonymous();

            routes.MapPost("/login", Login)
            .Produces<AuthenticationResponse>(200)
            .AddEndpointFilter<ValidationFilter<LoginRequest>>()
            .AllowAnonymous();
        }

        private async Task<IResult> Register(IMediator mediator, RegisterRequest request)
        {
            var result = await mediator.Send(new RegisterCommand(request));
            return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
        }

        private async Task<IResult> Login(IMediator mediator, LoginRequest request)
        {
            var result = await mediator.Send(new AuthenticateCommand(request));
            return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.Unauthorized();
        }
    }
}
