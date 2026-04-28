using PatientInfo.Application.DTOs;
using PatientInfo.Domain.Entities;

namespace PatientInfo.Application.Interfaces;

public interface IPatientMapper
{
    PatientDTO ToDTO(Patient entity);
    Patient ToEntity(PatientDTO dto);
    IEnumerable<PatientDTO> ToDTOList(IEnumerable<Patient> entities);
}
