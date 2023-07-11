# Employee API

Welcome to the Employee API! This API allows you to perform CRUD (Create, Read, Update, Delete) operations on employees. It is built with .NET Core and utilizes IdentityServer4 for authentication. The API uses an in-memory database for storage. FluentValidation is used for input validation, and Mapster is used for object mapping.

## Getting Started

### Prerequisites

- .NET Core SDK (version 7.0 or higher) installed
- Postman (or any other HTTP client) installed

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/employee-api.git


### Configuration

IdentityServer:Authority: https://localhost:5001

IdentityServer:ClientId: client

IdentityServer:ClientSecret: secret

### Usage

1. Start IdenditityServer and EmployeeApi
2. Obtain a bearer token:
   
To access the API endpoints, you need a bearer token. Use the following cURL command or any other HTTP client to request a token:

  ```bash
  curl -X POST -H "Content-Type: application/x-www-form-urlencoded" -d "grant_type=client_credentials&client_id <client_id>&client_secret=<client_secret>&scope= <api_scope>" https://localhost:5001/connect/token
```   

3. API Endpoints:

- POST /api/employee - Create a new employee. Requires authentication.
- GET /api/employee - Get a list of all employees. Requires authentication.
- GET /api/employee/{id} - Get an employee by ID. Requires authentication.
- PUT /api/employee/{id} - Update an employee by ID. Requires authentication.
- DELETE /api/employee/{id} - Delete an employee by ID. Requires authentication.

For each endpoint, include the bearer token obtained in the Authorization header as follows:
```bash
Authorization: Bearer <bearer_token>
```

Replace `<bearer_token>` with the actual bearer token value.

4. Testing with Postman:
   
You can import the provided Postman collection (employee-api.postman_collection.json) into Postman. The collection contains pre-configured requests for each API endpoint. Make sure to update the environment variables with your own values before executing the requests.

### Validation
   
Input validation is performed using FluentValidation. The API ensures that the employee data sent in the requests is valid according to the defined rules.

###  Object Mapping

The API uses Mapster for object mapping. It simplifies the mapping process between different object types, allowing for efficient conversion of employee data between the API models and the in-memory database entities.




