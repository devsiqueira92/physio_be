using Microsoft.AspNetCore.Http;
using Physio.API.Configurations;
using Physio.API.Filters;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.API.Endpoints;

public class ClinicEndpoint : IEndpointDefinition
{
	public void RegisterEndpoints(WebApplication app)
	{
		var routes = app.MapGroup("api/clinic");

        routes.MapGet("/", Get)
        .Produces<string>(404)
        .Produces<List<ClinicResponse>>(200);

        routes.MapGet("/{id}", GetById)
       .Produces<ClinicResponse>(200)
       .AllowAnonymous();

        routes.MapPost("/create", Create)
        .Produces<ClinicResponse>(200)
        .AddEndpointFilter<ValidationFilter<ClinicCreateRequest>>()
        .AllowAnonymous();

        routes.MapPut("/update", Update)
       .Produces<ClinicResponse>(200)
       .AddEndpointFilter<ValidationFilter<ClinicUpdateRequest>>()
       .AllowAnonymous();

        routes.MapDelete("/{id}", Delete)
       .AllowAnonymous();
    }

    //private async Task<IResult> GetClasses(IMediator mediator)
    //{
    //	var result = await mediator.Send(new GetClassesQuery());
    //	return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    //}

    private async Task<IResult> Get([AsParameters] PaginatedRequest request)
    {
        var result = new object();
        return result is not null ? TypedResults.Ok(result) : TypedResults.NotFound();
    }

    private async Task<IResult> GetById(string id)
    {
        var result = id;
        return TypedResults.Ok(result);
    }

    private async Task<IResult> Create(ClinicCreateRequest request)
    {
        var result = request;
        return TypedResults.Ok(result);
    }

    private async Task<IResult> Update(ClinicCreateRequest request)
    {
        var result = request;
        return TypedResults.Ok(result);
    }

    private async Task<IResult> Delete(string id)
    {
        return TypedResults.NoContent();
    }

}
