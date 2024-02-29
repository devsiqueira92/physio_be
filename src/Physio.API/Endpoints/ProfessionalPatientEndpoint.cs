using MediatR;
using Physio.API.Configurations;
using Physio.Application.ProfessionalPatient.Commands.AddExistingPatient;
using Physio.Application.ProfessionalPatient.Commands.AddPatient;
using Physio.Application.ProfessionalPatient.Queries.GetProfessionalPatients;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ProfessionalPatientEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/professional-patient");


        routes.MapGet("/", GetProfessionalPatients)
        .Produces(404)
        .Produces<List<PatientResponse>>(200);

        routes.MapPost("/add-patient", AddPatientToProfessional)
        .Produces<ProfessionalPatientResponse>(200);

        routes.MapPost("/add-existing-patient", AddExistingPatientToProfessional)
        .Produces<ProfessionalPatientResponse>(200);

    }


    private async Task<IResult> GetProfessionalPatients(IMediator mediator, [AsParameters] PaginatedRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new GetProfessionalPatientsQuery(request, userId));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> AddPatientToProfessional(IMediator mediator, ProfessionalPatientCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new AddProfessionalPatientCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> AddExistingPatientToProfessional(IMediator mediator, ProfessionalPatientAddExistingRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new AddExistingPatientCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }
}
