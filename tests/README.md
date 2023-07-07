# The Plotly.NET Test Suite

This folder contains all tests performed in this monorepo.

As It got quite large and complex, this reamde is a try to make things less opaque for contributors.

## Testing frameworks used

- Most of the F# test projects use [Expecto](https://github.com/haf/expecto), some use [xUnit](https://xunit.net/)

- The C# test projects use [xUnit](https://xunit.net/)

- The JS test projects use [Mocha](https://mochajs.org/)

## Running tests

### Using the `build` project

This is the main way of running tests from the command line. 

Either use `build.cmd` or `build.sh` depending on your OS to run test targets, e.g. :

```
build.cmd runTestsAll
build.sh runTestsCore
```

Available test targets are:

- `RunTestsAll` - runs all tests
- `RunTestsAllNoNetFX` - runs all tests except the ones that require .NET Framework
- `RunTestsCore` - runs all tests in the `CoreTests` folder except the ones that require .NET Framework
- `RunTestsCoreWithNetFX` - runs all tests in the `CoreTests` folder including the ones that require .NET Framework
- `RunTestsNetFX` - runs all tests that require .NET Framework
- `RunTestsExtensionLibs` - runs all tests in the `ExtensionLibTests` folder
- `RunTestsJSTests` - runs all tests in the `JSTests` folder

### Using Visual Studio Test Explorer

You can also run tests from within Visual Studio using the Test Explorer.

Just note that test projects targeting .NET Framework will not be visible in the Test Explorer, as they are not supported by the Test Explorer.

## Folder structure

### Common

`Common` contains all common code used in the test suite.
This includes the `TestUtils` and `TestCharts` modules, which contain utility functions for testing and the actual chart objets to use in tests.

The projects contained here are `FSharpTestBase.fsproj` and `CSharptestBase.csproj` - classlibs that contain the above for each language respectively.

### ConsoleApps

`ConsoleApps` is a folder containing projects that use any amount of the other projects in this repo.
They are not TestProjects as in that they contain UnitTests, but are more thought of as playgrounds 
to manually test functionality of the projects in a console application.

### CoreTests

`CoreTests` contains all UnitTests for the core `Plotly.NET` F# project. This is by far the largest test suite.

Currently, the following test projects are contained:

#### CoreTests.fsproj

The largets test suite by far that tests all things Plotly.NET, such as HTML code generation, JSON serialization, Object validity, etc.

#### CSharpInteroperabilityTests.csproj

Testing usage of the core F# API from C#

#### StrongNameTests.fsproj

Testing usage of the core F# in an environment that requires strong named libraries. This catches for example the addition of new dependencies that are not signed, and therefore cause errors in such an environment, but not in newer .NET environments.

### ExtensionLibTests

`ExtensionLibTests` contains all UnitTests for extension libraries, such as `Plotly.NET.CSharp` or `Plotly.NET.ImageExport`.

### JSTests

`JSTests` contains all UnitTests that run on node.js. The main application here is the validation of generated JSON via the `Plotly.validate` function in the `plotly.js` library.