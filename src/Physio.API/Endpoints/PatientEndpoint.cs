using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.Patient.Commands.Create;
using Physio.Application.Patient.Commands.Delete;
using Physio.Application.Patient.Commands.Update;
using Physio.Application.Patient.Queries.GetAll;
using Physio.Application.Patient.Queries.GetById;
using Physio.Application.Patient.Queries.GetByIdentificationNumber;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class PatientEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/patient");

        routes.MapGet("/", Get)
        .Produces(404)
        .Produces<List<PatientResponse>>(200);

        routes.MapGet("/{id}", GetPatientById)
        .WithName(nameof(GetPatientById))
        .Produces<PatientResponse>(200);

        routes.MapGet("search/{id}", GetPatientByDocument)
        .Produces<PatientResponse>(200);

        routes.MapPost("/create", Create)
        .Produces<PatientResponse>(200)
        .AddEndpointFilter<ValidationFilter<PatientCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<PatientUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> Get(IMediator mediator, [AsParameters] PaginatedRequest request)
    {
        var result = await mediator.Send(new GetPatientsQuery(request.pageSize, request.pageNumber));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> GetPatientById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetPatientQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> GetPatientByDocument(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetByIdentificationNumberQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.Empty;
    }

    private async Task<IResult> Create(IMediator mediator, PatientCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        var result = await mediator.Send(new CreatePatientCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ? 
            TypedResults.CreatedAtRoute(result.Value, nameof(GetPatientById), new { id = result.Value.id }) : 
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, PatientUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdatePatientCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ? 
            TypedResults.NoContent() : 
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeletePatientCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }
}
