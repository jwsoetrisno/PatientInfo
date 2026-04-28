using PatientInfo.Application.Interfaces;
using PatientInfo.Domain.Entities;
using PatientInfo.Infrastructure.Interfaces;
namespace PatientInfo.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly List<Patient> _data;

    public PatientRepository(IDataSeeder<Patient> seeder)
    {
        _data = seeder.GetSeed();
    }

    public Task<IEnumerable<Patient>> GetAllAsync()
        => Task.FromResult(_data.AsEnumerable());

    public Task<Patient?> GetByIdAsync(int id)
        => Task.FromResult(_data.FirstOrDefault(x => x.Id == id));

    public Task AddAsync(Patient patient)
    {
        _data.Add(patient);
        return Task.CompletedTask;
    }
}