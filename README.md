
![](docs/img/logo_title.svg)

![](https://img.shields.io/circleci/build/github/plotly/Plotly.NET)
[![](https://img.shields.io/nuget/vpre/Plotly.NET)](https://www.nuget.org/packages/Plotly.NET/)


Plotly.NET provides functions for generating and rendering plotly.js charts in **.NET** programming languages 📈🚀. 

### Table of contents 

- [Installation](#installation)
    - [For applications and libraries](#for-applications-and-libraries)
    - [For scripting](#for-scripting)
    - [For dotnet interactive notebooks](#for-dotnet-interactive-notebooks)
- [Documentation](#documentation)
    - [Getting started](#getting-started)
    - [Full library reference](#full-library-reference)
- [Develop](#develop)
    - [build](#build)
    - [docs](#docs)
- [Library license](#library-license)



# Installation

Plotly.NET will be available as 2.0.0 version of its predecessor FSharp.Plotly. The feature roadmap can be seen [here](https://github.com/plotly/Plotly.NET/issues/43). Contributions are very welcome!

Old packages up until version 1.2.2 can be accessed via the old package name *FSharp.Plotly* [here](https://www.nuget.org/packages/FSharp.Plotly/)

### For applications and libraries

A preview version of Plotly.NET 2.0.0 is available on nuget to plug into your favorite package manager:

 - dotnet CLI

```shell
dotnet add package Plotly.NET --version 2.0.0-alpha5
```

 - paket CLI

```shell
paket add Plotly.NET --version 2.0.0-beta1
```

 - package manager

```shell
Install-Package Plotly.NET -Version 2.0.0-beta1
```

Or add the package reference directly to your `.*proj` file:

```
<PackageReference Include="Plotly.NET" Version="2.0.0-beta1" />
```

### For scripting

You can include the package via an inline package reference:

```
#r "nuget: Plotly.NET, 2.0.0-beta1"
```

### For dotnet interactive notebooks

You can use the same inline package reference as in script, but as an additional goodie, 
the interactive extensions for dotnet interactive have you covered for seamless chart rendering:

```
#r "nuget: Plotly.NET, 2.0.0-beta1"
#r "nuget: Plotly.NET.Interactive, 2.0.0-beta1"
```

# Documentation

## Getting started

The landing page of our docs contains everything to get you started fast, check it out [📖 here](http://plotly.github.io/Plotly.NET/) 

## Full library reference

The API reference is available [📚 here](http://plotly.github.io/Plotly.NET/reference/index.html)

The documentation for this library is automatically generated (using FSharp.Formatting) from *.fsx and *.md files in the docs folder. If you find a typo, please submit a pull request!

# Development

### build

Check the [build.fsx file](https://github.com/plotly/Plotly.NET/blob/dev/build.fsx) to take a look at the  build targets. Here are some examples:

```shell
# Windows

# Build, test, pack nuget, build docs
./build.cmd -t all 

# Build only
./build.cmd

# Linux/mac

# Build, test, pack nuget, build docs
./build.sh -t all 

# Build only
./build.sh
```

### docs

The docs are contained in `.fsx` and `.md` files in the `docs` folder. To develop docs on a local server with hot reload, run the following in the root of the project:

```shell
# Windows
./build.cmd -t watchdocs

# Linux/mac
./build.sh -t watchdocs
```


### release

Library license
===============

The library is available under the [MIT license](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).