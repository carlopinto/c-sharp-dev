# Pizza site - Minimal API

.NET 8 | Swagger | in-memory DB to store data | EF Core | Persist data to a SQLite DB

Create a minimal API with `dotnet new web`

Add EF Core:
    `dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 8.0`

Add SQLite package
    `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0`

Add EF Core tools
    `dotnet tool install --global dotnet-ef`

Add EF Core Design
    `dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0`

Generate your first migration
    `dotnet ef migrations add InitialCreate`
Create your database and schema
    `dotnet ef database update`

From the Microsoft training exercise:
- https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-api/
- https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-database/
