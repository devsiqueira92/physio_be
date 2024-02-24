using FluentValidation;
using System.Net;

namespace Physio.API.Filters;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T argToValidate = context.GetArgument<T>(1);
        IValidator<T> validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is not null)
        {
            var validationResult = await validator.ValidateAsync(argToValidate!);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
            }
        }
        // Otherwise invoke the next filter in the pipeline
        return await next.Invoke(context);
    }
}
