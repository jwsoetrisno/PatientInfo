using Microsoft.AspNetCore.Mvc;
using PatientInfo.Application.Interfaces;
using PatientInfo.Application.Services;

namespace PatientInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(IPatientService service) : BasedPatientsController
{
    private readonly IPatientService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
            return BadRequest();

        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return ResourceNotFound(id);

        return Ok(result);
    }
}