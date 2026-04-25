# FinFlow.Core - Financial Workflow API

FinFlow is a secure, role-based workflow and fund transfer API developed with enterprise standards. This ASP.NET Core-based API allows clients to create transfer requests and enables administrators to securely approve or reject these requests while maintaining a strict audit trail.

## Technologies and Architecture

* Framework: .NET Core (C#)
* Database: MS SQL Server & Entity Framework Core (Code-First)
* Security: JWT (JSON Web Token) Authentication & BCrypt Password Hashing
* Documentation: Swagger / OpenAPI
* Architecture Approach: N-Tier Architecture (Entities, DTOs, Services, Controllers)

## Key Enterprise Features

* Security (JWT & Role-Based Auth): Strict separation of User and Admin roles. Route-level authorization controls are implemented to secure administrative endpoints.
* Concurrency Control (Optimistic Concurrency): Integrated RowVersion tracking to prevent data conflicts when multiple administrators attempt to modify the same request simultaneously.
* Audit Trail: Adhering to financial software standards, every approved or rejected request is permanently logged in the ApprovalHistories table. This ensures full traceability regarding who performed an action, when it occurred, and the accompanying notes.
* Global Exception Handling: A custom ExceptionMiddleware is implemented to catch application-wide errors gracefully, ensuring the client always receives a clean, standardized JSON response rather than a server stack trace.
* Financial Data Integrity: Applied decimal(18,2) precision constraints to all financial values to prevent rounding errors or data loss.

## API Endpoints

### Authentication
* POST /api/Auth/register - Register a new user account.
* POST /api/Auth/login - Authenticate a user and generate a JWT.

### Workflow (Client)
* POST /api/Workflow/create - Create a new fund transfer request (Requires User or Admin role).
* GET /api/Workflow/my-requests - Retrieve a list of transfer requests created by the authenticated user.

### Workflow (Administration)
* GET /api/Workflow/pending - Retrieve a list of all pending transfer requests (Requires Admin role).
* POST /api/Workflow/{id}/approve - Approve a specific request and append an audit note (Requires Admin role).
* POST /api/Workflow/{id}/reject - Reject a specific request and append a rejection reason (Requires Admin role).

## Local Setup Instructions

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Locate the appsettings.json file and update the DefaultConnection string to match your local SQL Server configuration.
4. Open the Package Manager Console and run the following command to apply the database migrations:
   Update-Database
5. Build and run the project. You can interact with and test the endpoints directly through the automatically launched Swagger UI.