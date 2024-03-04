using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.ClinicScheduling.Commands.Create;
using Physio.Application.ClinicScheduling.Queries.GetByMonthYear;
using Physio.Application.Scheduling.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ClinicSchedulingEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/clinic-scheduling");

        routes.MapGet("/agenda", GetProfessionalAgenda)
        .Produces(404)
        .Produces<SchedulingResponse>(200);

        routes.MapPost("/create", Create)
        .Produces<SchedulingResponse>(200);
    }

    private async Task<IResult> GetProfessionalAgenda(IMediator mediator, [AsParameters] SchedulingMonthYearRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetByMonthYearQuery(request, userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }


    private async Task<IResult> Create(IMediator mediator, SchedulingCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new CreateClinicSchedulingCommand(request, userId));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }
}
