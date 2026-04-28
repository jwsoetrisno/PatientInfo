using PatientInfo.Infrastructure.Data;

namespace PatientInfo.Tests.Infrastructure;

public class PatientSeedDataTests
{
    private PatientSeedData _seeder;

    [SetUp]
    public void Setup()
    {
        _seeder = new PatientSeedData();
    }

    [Test]
    public void Seed_Should_Return_6_Records()
    {
        // Act
        var result = _seeder.GetSeed();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(6));
    }

    [Test]
    public void Seed_Should_Have_Unique_Ids()
    {
        // Act
        var result = _seeder.GetSeed();

        var uniqueIds = result.Select(x => x.Id).Distinct().Count();

        // Assert
        Assert.That(uniqueIds, Is.EqualTo(result.Count));
    }

    [Test]
    public void Seed_Should_Contain_Valid_Data()
    {
        // Act
        var result = _seeder.GetSeed();

        var first = result.First();

        // Assert
        Assert.That(first.NHSNumber, Is.Not.Null.And.Not.Empty);
        Assert.That(first.Name, Is.Not.Null.And.Not.Empty);
        Assert.That(first.GPPractice, Is.Not.Null.And.Not.Empty);
    }
}
