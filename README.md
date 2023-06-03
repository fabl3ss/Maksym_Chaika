# Software Development Technologies Home Task

This repository contains BDD tests written with SpecFlow, testing basic Dropbox API functionality. \
There are 3 scenarios defined: Upload File, Get File Metadata, and Delete File.


- Feature files can be found in the `SDT/Features` directory.
- Steps are defined in the `SDT/Steps` directory.

## Dependencies

The following NuGet packages are used in this project:

- `dotenv.net/3.1.2`
- `Dropbox.Api/6.37.0`
- `FluentAssertions/6.2.0`
- `Microsoft.Extensions.DependencyInjection/8.0.0-preview.4.23259.5`
- `Microsoft.NET.Test.Sdk/17.0.0`
- `NUnit/3.13.2`
- `NUnit3TestAdapter/4.1.0`
- `SolidToken.SpecFlow.DependencyInjection/3.9.3`
- `SpecFlow.NUnit/3.9.22`
- `SpecFlow.Plus.LivingDocPlugin/3.9.57`

## Setup

In order to setup the environment:

1. You need to specify your Dropbox API **ACCESS_TOKEN** in the `.env` file located at `SDT/bin/Debug/net6.0/.env`

## Build
You can build the project using the following command:
```
dotnet build
```
Please ensure you have the .NET Core SDK installed in order to use the `dotnet` command.

## Running Tests

You can run the tests using the following command:

```
dotnet test
```