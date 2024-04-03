using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Scheduling.Commands.Create;
using Physio.Application.Scheduling.Commands.Delete;
using Physio.Application.Scheduling.Commands.FinishedStatus;
using Physio.Application.Scheduling.Commands.Update;
using Physio.Application.Scheduling.Queries.GetByDate;
using Physio.Application.Scheduling.Queries.GetById;
using Physio.Application.Scheduling.Queries.GetByMonthYear;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class SchedulingEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/scheduling");

        routes.MapGet("/{id}", GetById)
        .Produces(404)
        .Produces<SchedulingResponse>(200);

        routes.MapGet("/agenda", GetProfessionalAgenda)
        .Produces(404)
        .Produces<SchedulingResponse>(200);

        routes.MapGet("/by-date/{date}", GetByDate)
        .Produces(404)
        .Produces<SchedulingResponse>(200);

        routes.MapPost("/create", Create)
        .Produces<SchedulingResponse>(200);

        routes.MapPut("/update", Update)
        .Produces(204);

        routes.MapPut("/finished-status", FinishedStatus)
       .Produces(204);

        routes.MapDelete("/{id}", Delete)
        .Produces(400)
        .Produces(404)
        .Produces(204);
    }


    private async Task<IResult> GetById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetSchedulingQuery(id));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetProfessionalAgenda(IMediator mediator, [AsParameters] SchedulingMonthYearRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetByMonthYearQuery(request, userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetByDate(IMediator mediator, string date, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetByDateQuery(DateOnly.Parse(date), userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> Create(IMediator mediator, SchedulingCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new CreateSchedulingCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, SchedulingUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new UpdateSchedulingCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> FinishedStatus(IMediator mediator, Guid id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new FinishedStatusSchedulingCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id)
    {
        var result = await mediator.Send(new DeleteSchedulingCommand(Guid.Parse(id)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.NotFound(result.Error);
    }
}
