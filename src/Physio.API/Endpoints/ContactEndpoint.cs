using MediatR;
using Physio.API.Configurations;
using Physio.Application.Contact.Commands.Create;
using Physio.Application.Contact.Commands.Update;
using Physio.Application.Contact.Queries.GetById;
using Physio.Application.Contact.Queries.GetClinicContacts;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;
using System.Security.Claims;

namespace Physio.API.Endpoints;

public class ContactEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var routes = app.MapGroup("api/contact");


        routes.MapGet("/clinic-contacts", GetClinicContacts)
        .Produces<List<ContactResponse>>(200);

        routes.MapGet("/professional-contacts", GetProfessionalContacts)
        .Produces<List<ContactResponse>>(200);

        routes.MapGet("/{id}", GetById)
        .Produces<ContactResponse>(200);

        routes.MapPost("/create", Create)
        .Produces<ContactResponse>(200);

        routes.MapPut("/update", Update)
       .Produces(204);
    }


    private async Task<IResult> GetById(IMediator mediator, string id)
    {
        var result = await mediator.Send(new GetContactQuery(Guid.Parse(id)));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> GetClinicContacts(IMediator mediator, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetClinicContactsQuery(userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> GetProfessionalContacts(IMediator mediator, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await mediator.Send(new GetClinicContactsQuery(userId));

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Error);
    }


    private async Task<IResult> Create(IMediator mediator, ContactCreateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new CreateContactCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    private async Task<IResult> Update(IMediator mediator, ContactUpdateRequest request, HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await mediator.Send(new UpdateContactCommand(request, Guid.Parse(userId)));

        return result.IsSuccess ?
            TypedResults.NoContent() :
            TypedResults.BadRequest(result.Error);
    }

}
