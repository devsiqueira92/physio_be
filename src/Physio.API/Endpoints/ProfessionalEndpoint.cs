using MediatR;
using Microsoft.AspNetCore.Http;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Professional.Commands.Create;
using Physio.Application.Professional.Commands.Delete;
using Physio.Application.Professional.Commands.Update;
using Physio.Application.Professional.Queries.GetAll;
using Physio.Application.Professional.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ProfessionalEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/professional");

        routes.MapGet("/", Get)
        .Produces(404)
        .Produces<List<ProfessionalResponse>>(200);

        routes.MapGet("/{id}", GetProfessionalById)
        .WithName(nameof(GetProfessionalById))
        .Produces<ProfessionalResponse>(201);

        routes.MapPut("/update", Update)
        .Produces(204)
        .AddEndpointFilter<ValidationFilter<ProfessionalUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);

        //criar profissional independente, onde este irá ter um userID associado e ClinicId null
        routes.MapPost("/create", Create)
        .Produces<ProfessionalResponse>(200)
        .AddEndpointFilter<ValidationFilter<ProfessionalCreateRequest>>();

        //criar profissional para uma clinica, onde este irá ter um clinicId associado e userId null
        routes.MapPost("/create-clinic-professional", Create)
        .Produces<ProfessionalResponse>(200)
        .AddEndpointFilter<ValidationFilter<ProfessionalCreateRequest>>();
    }

    private async Task<IResult> Get(IMediator mediator, [AsParameters] PaginatedRequest request)
    {
        var result = await mediator.Send(new GetProfessionalsQuery(request.pageSize, request.pageNumber));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetProfessionalById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetProfessionalQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, ProfessionalCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateProfessionalCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.CreatedAtRoute(result.Value, nameof(GetProfessionalById), new { id = result.Value.id }) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, ProfessionalUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateProfessionalCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteProfessionalCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }




}
