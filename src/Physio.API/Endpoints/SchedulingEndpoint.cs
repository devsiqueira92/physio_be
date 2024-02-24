using MediatR;

using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Scheduling.Commands.Create;
using Physio.Application.Scheduling.Commands.Delete;
using Physio.Application.Scheduling.Commands.Update;
using Physio.Application.Scheduling.Commands.UpdateStatusScheduling;
using Physio.Application.Scheduling.Queries.GetAll;
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

        routes.MapGet("/", Get)
       .Produces(404)
       .Produces<List<SchedulingResponse>>(200);

        routes.MapGet("/by-month-year", GetByMonthYear)
       .Produces(404)
       .Produces<List<SchedulingResponse>>(200);

        routes.MapGet("/{id}", GetSchedulingById)
        .WithName(nameof(GetSchedulingById))
        .Produces<SchedulingResponse>(201);

        routes.MapGet("by-date", GetSchedulingGetByDate)
        .AllowAnonymous()
        .WithName(nameof(GetSchedulingGetByDate))
        .Produces<SchedulingResponse>(201);

        routes.MapPost("/create", Create)
        .Produces<SchedulingResponse>(200)
        .AddEndpointFilter<ValidationFilter<SchedulingCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<SchedulingUpdateRequest>>();

        routes.MapPut("/finish-status", FinishStatusScheduling)
       .Produces(204);

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator, [AsParameters] PaginatedRequest request)
    {
        var result = await mediator.Send(new GetSchedulingsQuery(request.pageSize, request.pageNumber));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetByMonthYear(IMediator mediator, [AsParameters] SchedulingMonthYearRequest request)
    {
        var result = await mediator.Send(new GetByMonthYearQuery(request));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetSchedulingGetByDate(IMediator mediator, DateOnly date)
    {
        var result = await mediator.Send(new GetByDateQuery(date));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> GetSchedulingById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetSchedulingQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, SchedulingCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateSchedulingCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.CreatedAtRoute(result.Value, nameof(GetSchedulingById), new { id = result.Value.id }) :
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

    private async Task<IResult> FinishStatusScheduling(IMediator mediator, SchedulingUpdateStatusRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateStatusSchedulingCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteSchedulingCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }


}
