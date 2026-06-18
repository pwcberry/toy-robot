# Toy Robot

My submission for the Toy Robot exercise.

## Build

To build the code for this exercise, from the root directory execute the following commands:

```shell
dotnet restore
dotnet build
```

## Run

I have added an example input file in `samples/example4.txt`. To run the application with this input file, run either 
of the following commands from the solution root directory:

```powershell
Get-Content -Path .\samples\example4.txt | dotnet run --project .\ToyRobot.App\ToyRobot.App.csproj
```

Or on Linux/Mac:

```bash
cat ./samples/example4.txt | dotnet run --project ./ToyRobot.App/ToyRobot.App.csproj
```

The result of the `REPORT` command is `0,0,EAST`.

It is also possible to run the application interactively from the console or CLI. 
To do this, run the following command from the solution root directory:

```shell
dotnet run --project .\ToyRobot.App\ToyRobot.App.csproj
```

Then you can enter commands one at a time. Entering `QUIT` will exit the application.

## Test

To run the unit test project, use the following command:

```shell
dotnet test
```

## Explanation

The key considerations for my implementation were:

* Testability;
* Separation of concerns; and
* Decoupled components.

### Testability

It is important to test the code to verify that it works as expected. Unit tests allow for speedy feedback on the code, 
and also help to catch bugs.

### Separation of concerns

The execution of the application is separated into different components, each with a specific responsibility. 
Especially the user interaction: the `Controller` class provides the behaviour to ensure that input and output 
are handled without the awareness of other components.

### Decoupled components

This follows on from the preceding points: the components are decoupled from each other, 
so that they can be developed and tested independently, reducing the risk of bugs when changes are made. 
The `Robot` class is aware of the `Table` class, but not the other way around. A `Robot` needs to understand its 
boundaries, but a `Table` does not need to know about the `Robot`.

For the reader of the code, these design decisions should reduce cognitive load when trying to understand the code.

## Tools used

* Visual Studio Community (Windows)
* JetBrains Rider (Mac)
* .NET 10.0 SDK
* xUnit for unit testing
* Git for version control
* GitHub for hosting the repository

## Artificial Intelligence

I did use AI to assist in writing some of the code, mostly to:

* Write unit tests
* To implement the methods defined in the interface of `IEquatable<T>`

See the [Prompts document](./Prompts.md) for more details of the Copilot interactions.
