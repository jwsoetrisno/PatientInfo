using Microsoft.AspNetCore.Http;
using PatientInfo.Application.Interfaces;

namespace PatientInfo.Tests.Api.Fakes;

public class FakeAuthorizationService : IPatientAuthenticator
{
    private readonly bool _result;

    public FakeAuthorizationService(bool result)
    {
        _result = result;
    }

    public Task<bool> IsValidApiKeyAsync(string? apiKey)
    {
        return Task.FromResult(_result);
    }
}