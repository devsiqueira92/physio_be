using System.Security.Claims;

namespace Physio.API.Middlewares
{
    public class UserIdentificationMiddleware : IMiddleware
    {


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Verifica se a requisição é POST ou PUT
            if (context.Request.Method != HttpMethod.Get.ToString())
            {
                // Extrai o ID do usuário do token JWT
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    // Armazena o ID do usuário em HttpContext.Items para uso posterior
                    context.Items["UserId"] = userId;
                }
            }

            // Chama o próximo middleware na pipeline
            await next(context);
        }
    }
}
