using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.StatusScheduling.Commands.Create;
using Physio.Application.StatusScheduling.Commands.Delete;
using Physio.Application.StatusScheduling.Commands.Update;
using Physio.Application.StatusScheduling.Queries.GetAll;
using Physio.Application.StatusScheduling.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class StatusSchedulingEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/status-scheduling");

        routes.MapGet("/", Get)
       .Produces(404)
       .Produces<List<StatusSchedulingResponse>>(200);

        routes.MapGet("/{id}", GetStatusSchedulingById)
        .WithName(nameof(GetStatusSchedulingById))
        .Produces<StatusSchedulingResponse>(201);

        routes.MapPost("/create", Create)
        .Produces<StatusSchedulingResponse>(200)
        .AddEndpointFilter<ValidationFilter<StatusSchedulingCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<StatusSchedulingUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator)
    {
        var result = await mediator.Send(new GetStatusSchedulingsQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetStatusSchedulingById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetStatusSchedulingQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, StatusSchedulingCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateStatusSchedulingCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.CreatedAtRoute(result.Value, nameof(GetStatusSchedulingById), new { id = result.Value.id }) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, StatusSchedulingUpdateRequest request, HttpContext httpContext)
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
        var result = await mediator.Send(new DeleteStatusSchedulingCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

}
