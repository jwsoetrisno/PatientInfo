using PatientInfo.Application.Interfaces;

namespace PatientInfo.Api.Middlewares;

public class SecurityMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IPatientAuthenticator authService, IWebHostEnvironment webHost)
    {
        if (webHost.EnvironmentName == "Testing")
        {
            await next(context);
            return;
        }
        var apiKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

        if (!await authService.IsValidApiKeyAsync(apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var response = new
            {
                status = 401,
                message = "Unauthorized: Provide a valid API Key."
            };

            await context.Response.WriteAsJsonAsync(response);
            return;
        }

        await next(context);

    }
}