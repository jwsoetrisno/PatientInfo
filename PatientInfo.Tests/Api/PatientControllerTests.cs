using PatientInfo.Application.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace PatientInfo.Tests.Api;

public class PatientControllerTests
{
    private ApiFactory _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new ApiFactory(authResult: true);
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    [Test]
    public async Task GetAll_Should_Return_Ok()
    {
        var response = await _client.GetAsync("/api/Patients");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var data = await response.Content.ReadFromJsonAsync<List<PatientDTO>>();
        Assert.That(data, Is.Not.Null);
    }

    [Test]
    public async Task GetById_Should_Return_NotFound_When_Invalid()
    {

        var response = await _client.GetAsync("/api/Patients/999");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

}

