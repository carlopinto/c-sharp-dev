# Huge CSV Generator

Build an app that creates huge CSV files of sample data you generate and then optimise it.

## Setup

Initial steps to setup the project:

- dotnet new sln --name c-sharp-dev

- dotnet new console -n HugeCSVGenerator

- dotnet sln add .\HugeCSVGenerator\HugeCSVGenerator.csproj

Then we add unit testing using xUnit:

- dotnet new xunit -o HugeCSVGenerator.Tests

- dotnet sln add .\HugeCSVGenerator.Tests\HugeCSVGenerator.Tests.csproj

- dotnet add .\HugeCSVGenerator.Tests\HugeCSVGenerator.Tests.csproj reference .\HugeCSVGenerator\HugeCSVGenerator.csproj

## Development

Start by adding a class in `Program.cs` with the Main method and another empty method to generate a csv file, so it is callable from the test class.

We move to the test project and add tests to cover main functionality, edge cases and limits.

The challenge is about creating huge files which could imply:
- endless rows
- endless columns
- both

We are not dealing with a specific set of data, but we can assume that:
- we have only 10 columns
- we don't have to know what those columns are (let's use C1, C2, etc)
- the values are initially all integers (negative or positive)

1. WriteAllText 
    
    We create all the rows, store the content into a string and then write all the text to the file.

    By running the three tests, we notice that the code works well for a limited number of rows, but it can't handle 10 million rows.





