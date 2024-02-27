using MediatR;
using Microsoft.AspNetCore.Http;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Clinic.Commands.Create;
using Physio.Application.Clinic.Commands.Delete;
using Physio.Application.Clinic.Commands.Update;
using Physio.Application.Clinic.Queries.GetAccount;
using Physio.Application.Clinic.Queries.GetAll;
using Physio.Application.Clinic.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ClinicEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/clinic");

        routes.MapGet("/", Get)
        .Produces(404)
        .Produces<List<ClinicResponse>>(200);

        routes.MapGet("/account", GetAccount)
        .Produces(404)
        .Produces<List<ClinicResponse>>(200);

        routes.MapGet("/{id}", GetClinicById)
        .WithName(nameof(GetClinicById))
        .Produces<ClinicResponse>(201);

        routes.MapPost("/create", Create)
        .Produces<ClinicResponse>(200)
        .AddEndpointFilter<ValidationFilter<ClinicCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<ClinicUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator, [AsParameters] PaginatedRequest request)
    {
        var result = await mediator.Send(new GetClinicsQuery(request.pageSize, request.pageNumber));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetAccount(IMediator mediator, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetAccountQuery(userId));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetClinicById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetClinicQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, ClinicCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateClinicCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, ClinicUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateClinicCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteClinicCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }
}
