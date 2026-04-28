using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using PatientInfo.Api;
using PatientInfo.Tests.Api.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PatientInfo.Application.Interfaces;


namespace PatientInfo.Tests.Api;

public class ApiFactory : WebApplicationFactory<Program>
{
    private readonly bool _authResult;

    public ApiFactory(bool authResult = true)
    {
        _authResult = authResult;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            // remove real auth service
            services.RemoveAll<IAuthorizationService>();

            // inject fake auth service
            services.AddScoped<IPatientAuthenticator>(
                _ => new FakeAuthorizationService(_authResult)
            );
        });
    }
}