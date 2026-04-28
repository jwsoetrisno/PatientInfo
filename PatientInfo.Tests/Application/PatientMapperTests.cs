using PatientInfo.Application.DTOs;
using PatientInfo.Application.Mappings;
using PatientInfo.Domain.Entities;

namespace PatientInfo.Tests.Application;

public class PatientMapperTests
{
    private PatientMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _mapper = new PatientMapper();
    }

    #region Entity -> DTO

    [Test]
    public void ToDto_Should_Map_Entity_To_Dto_Correctly()
    {
        // Arrange
        var entity = new Patient(
            1,
            "NHSK001",
            "John Doe",
            new DateTime(1990, 1, 1),
            "Practice A"
        );

        // Act
        var result = _mapper.ToDTO(entity);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(entity.Id));
        Assert.That(result.NHSNumber, Is.EqualTo(entity.NHSNumber));
        Assert.That(result.Name, Is.EqualTo(entity.Name));
        Assert.That(result.DateOfBirth, Is.EqualTo(entity.DateOfBirth));
        Assert.That(result.GPPractice, Is.EqualTo(entity.GPPractice));
    }

    #endregion

    #region DTO -> Entity

    [Test]
    public void ToEntity_Should_Map_Dto_To_Entity_Correctly()
    {
        // Arrange
        var dto = new PatientDTO
        {
            Id = 2,
            NHSNumber = "NHS002",
            Name = "Jane Doe",
            DateOfBirth = new DateTime(1985, 5, 20),
            GPPractice = "GP Practice B"
        };

        // Act
        var result = _mapper.ToEntity(dto);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(dto.Id));
        Assert.That(result.NHSNumber, Is.EqualTo(dto.NHSNumber));
        Assert.That(result.Name, Is.EqualTo(dto.Name));
        Assert.That(result.DateOfBirth, Is.EqualTo(dto.DateOfBirth));
        Assert.That(result.GPPractice, Is.EqualTo(dto.GPPractice));
    }

    #endregion

    #region List Mapping

    [Test]
    public void ToDtoList_Should_Map_All_Entities()
    {
        // Arrange
        var entities = new List<Patient>
        {
            new Patient(1, "NHS001", "John", DateTime.Now.AddYears(-30), "GP Practice A"),
            new Patient(2, "NHS002", "Jane", DateTime.Now.AddYears(-25), "GP Practice B")
        };

        // Act
        var result = _mapper.ToDTOList(entities).ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Id, Is.EqualTo(1));
        Assert.That(result[0].NHSNumber, Is.EqualTo("NHS001"));
        Assert.That(result[0].Name, Is.EqualTo("John"));
        Assert.That(result[0].GPPractice, Is.EqualTo("GP Practice A"));
        Assert.That(result[1].Id, Is.EqualTo(2));
        Assert.That(result[1].NHSNumber, Is.EqualTo("NHS002"));
        Assert.That(result[1].Name, Is.EqualTo("Jane"));
        Assert.That(result[1].GPPractice, Is.EqualTo("GP Practice B"));
    }

    #endregion
}
