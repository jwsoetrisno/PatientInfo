using PatientInfo.Domain.Entities;
using PatientInfo.Infrastructure.Interfaces;

namespace PatientInfo.Infrastructure.Data;

public class PatientSeedData : IDataSeeder<Patient>
{
    public List<Patient> GetSeed()
    {
        return
                [
                    new Patient(1, "NHS001", "John Doe", new DateTime(1990,1,1), "GP Practice A"),
                    new Patient(2, "NHS002", "Jane Smith", new DateTime(1985,5,20), "GP Practice B"),
                    new Patient(3, "NHS003", "Michael Brown", new DateTime(1978,3,10), "GP Practice C"),
                    new Patient(4, "NHS004", "Emily Davis", new DateTime(1992,7,15), "GP Practice A"),
                    new Patient(5, "NHS005", "Chris Wilson", new DateTime(1988,11,25), "GP Practice B"),
                    new Patient(6, "NHS006", "Sarah Taylor", new DateTime(1995,9,5), "GP Practice C")
                ];
    }
}