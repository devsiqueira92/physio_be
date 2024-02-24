using MediatR;
using Physio.API.Configurations;
using Physio.Application.ClinicProfessional.Commands.AddExistingProfessional;
using Physio.Application.ClinicProfessional.Commands.AddProfessional;
using Physio.Application.ClinicProfessional.Queries.GetClinicProfessionals;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ClinicProfessionalEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/clinic-professional");
        
        routes.MapGet("/", GetClinicProfessionals)
        .Produces(404)
        .Produces<List<ProfessionalResponse>>(200);

        routes.MapPost("/add-professional", AddProfessionalToClinic)
        .Produces<ProfessionalClinicResponse>(200);

        routes.MapPost("/add-existing-professional", AddExistingProfessionalToClinic)
        .Produces<ProfessionalClinicResponse>(200);
    }

    private async Task<IResult> GetClinicProfessionals(IMediator mediator, [AsParameters] PaginatedRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetClinicProfessionalsQuery(request, userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> AddProfessionalToClinic(IMediator mediator, ProfessionalClinicCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new AddProfessionalCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> AddExistingProfessionalToClinic(IMediator mediator, ProfessionalClinicAddExistingRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        var result = await mediator.Send(new AddExistingProfessionalCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }
}
