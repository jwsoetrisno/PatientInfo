using PatientInfo.Application.DTOs;
using PatientInfo.Application.Interfaces;


namespace PatientInfo.Application.Services;

public class PatientService(IPatientRepository repository, IPatientMapper mapper) : IPatientService
{
    private readonly IPatientRepository _repository = repository;
    private readonly IPatientMapper _mapper = mapper;

    public async Task<IEnumerable<PatientDTO>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return _mapper.ToDTOList(data);
    }

    public async Task<PatientDTO?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity == null ? null : _mapper.ToDTO(entity);
    } 
}