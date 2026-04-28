namespace PatientInfo.Domain.Entities;

public class Patient
{
    public int Id { get; private set; }
    public string NHSNumber { get; private set; }
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string GPPractice { get; private set; }

    public Patient(int id, string nhsNumber, string name, DateTime dateOfBirth, string gpPractice)
    {
        Id = id;
        NHSNumber = nhsNumber;
        Name = name;
        DateOfBirth = dateOfBirth;
        GPPractice = gpPractice;
    }
}