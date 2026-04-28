namespace PatientInfo.Application.Interfaces;

public interface IPatientAuthenticator
{
    Task<bool> IsValidApiKeyAsync(string? apiKey);
}