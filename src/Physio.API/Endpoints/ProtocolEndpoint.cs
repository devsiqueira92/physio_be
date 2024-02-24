using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Protocol.Commands.Create;
using Physio.Application.Protocol.Commands.Delete;
using Physio.Application.Protocol.Commands.Update;
using Physio.Application.Protocol.Queries.GetAll;
using Physio.Application.Protocol.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ProtocolEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/protocol");

        routes.MapGet("/", Get)
       .Produces(404)
       .Produces<List<ProtocolResponse>>(200);

        routes.MapGet("/{id}", GetProtocolById)
        .WithName(nameof(GetProtocolById))
        .Produces<ProtocolResponse>(201);

        routes.MapPost("/create", Create)
        .Produces<ProtocolResponse>(200)
        .AddEndpointFilter<ValidationFilter<ProtocolCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<ProtocolUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator, [AsParameters] PaginatedRequest request)
    {
        var result = await mediator.Send(new GetProtocolsQuery(request.pageSize, request.pageNumber));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetProtocolById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetProtocolQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, ProtocolCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateProtocolCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.CreatedAtRoute(result.Value, nameof(GetProtocolById), new { id = result.Value.id }) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, ProtocolUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateProtocolCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteProtocolCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

}
