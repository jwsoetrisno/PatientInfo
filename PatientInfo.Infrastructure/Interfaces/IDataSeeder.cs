namespace PatientInfo.Infrastructure.Interfaces;

public interface IDataSeeder<T>
{
    List<T> GetSeed();
}