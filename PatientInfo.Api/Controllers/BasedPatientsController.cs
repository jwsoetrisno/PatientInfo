using Microsoft.AspNetCore.Mvc;

namespace PatientInfo.Api.Controllers;

public class BasedPatientsController : ControllerBase
{
    protected ObjectResult ResourceNotFound(int? id = null)
    {
        string message = "The requested resource could not be found.";

        if (id.HasValue)
            message = $"Patient with ID {id.Value} could not be found. Please verify the ID or contact support.";

        return Problem(
                type: "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                title: "Resource Not Found",
                detail: message,
                instance: Request?.Path,
                statusCode: StatusCodes.Status404NotFound
            );
    }
}


