using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.SchedulingType.Commands.Create;
using Physio.Application.SchedulingType.Commands.Delete;
using Physio.Application.SchedulingType.Commands.Update;
using Physio.Application.SchedulingType.Queries.GetAll;
using Physio.Application.SchedulingType.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class SchedulingTypeEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/scheduling-type");

        routes.MapGet("/", Get)
       .Produces(404)
       .Produces<List<SchedulingTypeResponse>>(200);

        routes.MapGet("/{id}", GetSchedulingTypeById)
        .WithName(nameof(GetSchedulingTypeById))
        .Produces<SchedulingTypeResponse>(201);

        routes.MapPost("/create", Create)
        .Produces<SchedulingTypeResponse>(200)
        .AddEndpointFilter<ValidationFilter<SchedulingTypeCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<SchedulingTypeUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator)
    {
        var result = await mediator.Send(new GetSchedulingTypesQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetSchedulingTypeById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetSchedulingTypeQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, SchedulingTypeCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateSchedulingTypeCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.CreatedAtRoute(result.Value, nameof(GetSchedulingTypeById), new { id = result.Value.id }) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, SchedulingTypeUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateSchedulingTypeCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteSchedulingTypeCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

}
