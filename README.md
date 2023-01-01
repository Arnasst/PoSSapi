# Point of Sale System

This is an API of a Point of Sale System.
Based on [Clean Architecture template](https://github.com/jasontaylordev/CleanArchitecture).
Check out this [blog post](https://jasontaylor.dev/clean-architecture-getting-started/) for more information.

## Implementation sequence

PRADa_USM → QuickFix_Technical_Design_Document + API_endpoints.yaml → This

## Swagger

To view QuickFix described endpoints go to: <https://editor.swagger.io/> and paste in the contents of the API_endpoints.yaml file.

TODO: add a document with what was changed.

## Getting Started

1. Install the latest [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
2. Install the latest [Node.js LTS](https://nodejs.org/en/)
3. Navigate to `PoSSapi/src/WebUI` and launch the project using `dotnet run`
4. After launching the project endpoints can be accessed at <https://localhost:5000/api/> for example to get all businesses you'd send a GET request to <https://localhost:5000/api/business/list>.

Controllers and the endpoints are located in `PoSSapi/src/WebUI/Controllers`.
