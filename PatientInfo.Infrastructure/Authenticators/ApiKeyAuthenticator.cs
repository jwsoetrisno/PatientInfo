using Microsoft.Extensions.Options;
using PatientInfo.Application.Configurations;
using PatientInfo.Application.Interfaces;

namespace PatientInfo.Infrastructure.Authenticators;

public class ApiKeyAuthenticator : IPatientAuthenticator
{
    private readonly string _apiKey;

    public ApiKeyAuthenticator(IOptions<ApiKeySettings> options)
    {
        _apiKey = options.Value.ApiKey;
    }

    public Task<bool> IsValidApiKeyAsync(string? apiKey)
    {
        var isValid = !string.IsNullOrWhiteSpace(apiKey)
                      && apiKey == _apiKey;

        return Task.FromResult(isValid);
    }

}