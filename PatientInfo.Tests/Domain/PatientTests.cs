using PatientInfo.Domain.Entities;

namespace PatientInfo.Tests.Domain;

public class PatientTests
{
    [Test]
    public void Constructor_Should_Set_Properties_Correctly()
    {
        var dob = new DateTime(1990, 1, 1);

        var patient = new Patient(1, "NHS001", "John Doe", dob, "GP Practice A");

        Assert.That(patient.Id, Is.EqualTo(1));
        Assert.That(patient.NHSNumber, Is.EqualTo("NHS001"));
        Assert.That(patient.Name, Is.EqualTo("John Doe"));
        Assert.That(patient.DateOfBirth, Is.EqualTo(dob));
        Assert.That(patient.GPPractice, Is.EqualTo("GP Practice A"));
    }
}
