using PatientInfo.Application.DTOs;

namespace PatientInfo.Application.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<PatientDTO>> GetAllAsync();
    Task<PatientDTO?> GetByIdAsync(int id);
}