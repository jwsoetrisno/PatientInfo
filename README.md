# Get Patient Summary

The project demonstrates implementation of an API endpoint that returns a patient summary based on a given ID.
Since the scenario is in a healthcare system, API key authentication is provided to represent secure access.
This API endpoint is built using .NET technology and C# with a clean and maintainable Web API by separation of concerns
across Domain, Application, Infrastructure, and API layers, and structured error handling.

---

## 📌 Features

- Get Patient Summary (Get By ID)
- Accepts a patient ID as input
- Returns the patient's details if found
- Returns an appropriate response if the patient is not found
- No database used
- Sample data available 6 records, with Id 1 to 6
- Unit Test is provided
---

### 📡 API Endpoints
**Get patient summary by patient ID**
```
GET /api/patients/{id}
```

### ❗Error Handling Example
**Patient not found**
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Resource Not Found",
  "status": 404,
  "detail": "Patient with ID 999 could not be found.",
  "instance": "/api/patients/999"
}
```

## 🔐 Authentication

This API uses API Key authentication.

### Required header:
```
X-API-Key: NHS2026
```
### Unauthorized response:
```json
{
  "status": 401,
  "error": "Unauthorized",
  "message": "Unauthorized: Provide a valid API Key."
}

```

## 🔐 Author

Built as .NET coding challenge: Get Patient Summary with scenario 
working in a healthcare system that stores basic patient information. 
Implement an API endpoint that returns a patient summary based on a given ID.
