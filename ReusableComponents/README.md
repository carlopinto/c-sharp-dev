# Build reusable components with Blazor

From Microsoft training https://learn.microsoft.com/en-us/training/modules/blazor-build-reusable-components/

Create a Razor class library

    dotnet add reference ../FirstClassLibrary

Package a Razor class library

    dotnet pack

Create a NuGet package

    dotnet add package My.FirstClassLibrary -s ..\FirstClassLibrary\bin\Debug
