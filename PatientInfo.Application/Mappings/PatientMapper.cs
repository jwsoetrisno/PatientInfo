using PatientInfo.Application.DTOs;
using PatientInfo.Application.Interfaces;
using PatientInfo.Domain.Entities;

namespace PatientInfo.Application.Mappings;

public class PatientMapper : IPatientMapper
{
    public PatientDTO ToDTO(Patient entity)
    {
        return new PatientDTO
        {
            Id = entity.Id,
            NHSNumber = entity.NHSNumber,
            Name = entity.Name,
            DateOfBirth = entity.DateOfBirth,
            GPPractice = entity.GPPractice
        };
    }

    public Patient ToEntity(PatientDTO dto)
    {
        return new Patient(
            dto.Id,
            dto.NHSNumber,
            dto.Name,
            dto.DateOfBirth,
            dto.GPPractice
        );
    }

    public IEnumerable<PatientDTO> ToDTOList(IEnumerable<Patient> entities)
    {
        return entities.Select(ToDTO);
    }
}