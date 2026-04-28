using PatientInfo.Domain.Entities;
using PatientInfo.Infrastructure.Interfaces;
using PatientInfo.Infrastructure.Repositories;
using PatientInfo.Infrastructure.Data;

namespace PatientInfo.Tests.Infrastructure;

public class PatientRepositoryTests
{
    private PatientRepository _repository;

    [SetUp]
    public void Setup()
    {
        IDataSeeder<Patient> seeder = new PatientSeedData();
        _repository = new PatientRepository(seeder);
    }

    #region GetAllAsync

    [Test]
    public async Task GetAllAsync_Should_Return_Seeded_Data()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(6));
    }

    #endregion

    #region GetByIdAsync

    [Test]
    public async Task GetByIdAsync_Should_Return_Correct_Entity()
    {
        // Act
        var result = await _repository.GetByIdAsync(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Id, Is.EqualTo(1));
    }

    [Test]
    public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
    {
        // Act
        var result = await _repository.GetByIdAsync(999);

        // Assert
        Assert.That(result, Is.Null);
    }

    #endregion

    #region AddAsync

    [Test]
    public async Task AddAsync_Should_Add_New_Entity()
    {
        // Arrange
        var newEntity = new Patient(
            10,
            "NHS010",
            "New Patient",
            DateTime.Now.AddYears(-20),
            "GP Practice X"
        );

        // Act
        await _repository.AddAsync(newEntity);
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.That(result.Any(x => x.Id == 10), Is.True);
        Assert.That(result.Count(), Is.EqualTo(7));
    }

    #endregion
}
