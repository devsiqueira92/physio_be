using MediatR;
using Physio.API.Configurations;
using Physio.Application.ClinicPatient.Commands.AddExistingPatient;
using Physio.Application.ClinicPatient.Commands.AddPatient;
using Physio.Application.ClinicPatient.Queries.GetClinicPatients;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ClinicPatientEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/clinic-patient");


        routes.MapGet("/", GetClinicPatients)
        .Produces(404)
        .Produces<List<PatientResponse>>(200);

        routes.MapPost("/add-patient", AddPatientToClinic)
        .Produces<ClinicPatientResponse>(200);

        routes.MapPost("/add-existing-patient", AddExistingPatientToClinic)
        .Produces<ClinicPatientResponse>(200);

    }


    private async Task<IResult> GetClinicPatients(IMediator mediator, [AsParameters] PaginatedRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new GetClinicPatientsQuery(request, userId));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NoContent();
    }

    private async Task<IResult> AddPatientToClinic(IMediator mediator, ClinicPatientCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var clinicId = httpContext.User.FindFirst("cln")?.Value;

        var result = await mediator.Send(new AddClinicPatientCommand(request, Guid.Parse(userId), Guid.Parse(clinicId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> AddExistingPatientToClinic(IMediator mediator, ClinicPatientAddExistingRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var clinicId = httpContext.User.FindFirst("cln")?.Value;

        var result = await mediator.Send(new AddExistingPatientCommand(request, Guid.Parse(userId), Guid.Parse(clinicId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }
}
