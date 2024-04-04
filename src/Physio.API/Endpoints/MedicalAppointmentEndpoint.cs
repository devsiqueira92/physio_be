using MediatR;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Application.GetPatientAppointments.Queries.GetAll;
using Physio.Application.GetProfessionalAppointments.Queries.GetAll;
using Physio.Application.MedicalAppointment.Commands.Create;
using Physio.Application.MedicalAppointment.Commands.Delete;
using Physio.Application.MedicalAppointment.Commands.Update;
using Physio.Application.MedicalAppointment.Queries.GetById;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class MedicalAppointmentEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/medical-appointment");


        routes.MapGet("/", GetProfessionalAppointments)
        .Produces<List<MedicalAppointmentResponse>>(200);

        routes.MapGet("/{id}", Get)
        .Produces<MedicalAppointmentResponse>(200);

        routes.MapGet("/patient/{id}", GetPatientAppointments)
        .Produces<List<MedicalAppointmentResponse>>(200);

        routes.MapPost("/create", Create)
        .Produces<MedicalAppointmentResponse>(200)
        .AddEndpointFilter<ValidationFilter<MedicalAppointmentCreateRequest>>();

        routes.MapPut("/update", Update)
       .Produces(204)
       .AddEndpointFilter<ValidationFilter<MedicalAppointmentUpdateRequest>>();

        routes.MapDelete("/{id}", Delete)
        .Produces(204);
    }

    private async Task<IResult> GetProfessionalAppointments(IMediator mediator, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetProfessionalAppointmentsQuery(userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> GetPatientAppointments(IMediator mediator, string id, HttpContext httpContext)
    {
        var result = await mediator.Send(new GetPatientAppointmentsQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Get(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetMedicalAppointmentQuery(id));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Create(IMediator mediator, MedicalAppointmentCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateMedicalAppointmentCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, MedicalAppointmentUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateMedicalAppointmentCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Delete(IMediator mediator, string id, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new DeleteMedicalAppointmentCommand(id, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }
}
