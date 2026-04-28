using NSubstitute;
using PatientInfo.Application.DTOs;
using PatientInfo.Application.Interfaces;
using PatientInfo.Application.Services;
using PatientInfo.Domain.Entities;

namespace PatientInfo.Tests.Application;

public class PatientServiceTests
{
    private IPatientRepository _repository;
    private IPatientMapper _mapper;
    private PatientService _service;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<IPatientRepository>();
        _mapper = Substitute.For<IPatientMapper>();
        _service = new PatientService(_repository, _mapper);
    }

    #region GetAllAsync

    [Test]
    public async Task GetAllAsync_Should_Return_List_Of_DTOs()
    {
        // Arrange
        var entities = new List<Patient>
        {
            new Patient(1, "NHS001", "John", DateTime.Now.AddYears(-30), "GP Practice A")
        };

        var dtos = new List<PatientDTO>
        {
            new PatientDTO { Id = 1, Name = "John" }
        };

        _repository.GetAllAsync().Returns(entities);
        _mapper.ToDTOList(entities).Returns(dtos);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));

        await _repository.Received(1).GetAllAsync();
        _mapper.Received(1).ToDTOList(entities);
    }

    #endregion

    #region GetByIdAsync

    [Test]
    public async Task GetByIdAsync_Should_Return_DTO_When_Found()
    {
        // Arrange
        var entity = new Patient(1, "NHS001", "John", DateTime.Now.AddYears(-30), "GP Practice A");
        var dto = new PatientDTO { Id = 1, Name = "John" };

        _repository.GetByIdAsync(1).Returns(entity);
        _mapper.ToDTO(entity).Returns(dto);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Id, Is.EqualTo(1));

        await _repository.Received(1).GetByIdAsync(1);
        _mapper.Received(1).ToDTO(entity);
    }

    [Test]
    public async Task GetByIdAsync_Should_Return_Null_When_NotFound()
    {
        // Arrange
        _repository.GetByIdAsync(1).Returns((Patient?)null);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.That(result, Is.Null);
        await _repository.Received(1).GetByIdAsync(1);
        _mapper.DidNotReceive().ToDTO(Arg.Any<Patient>());
    }

    #endregion 

}
