
![](docs/img/logo_title.svg)

[![Build and test](https://github.com/plotly/Plotly.NET/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/plotly/Plotly.NET/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/vpre/Plotly.NET)](https://www.nuget.org/packages/Plotly.NET/)
[![Discord](https://img.shields.io/discord/836161044501889064?color=purple&label=Join%20our%20Discord%21&logo=discord&logoColor=white)](https://discord.gg/k3kUtFY8DB)
![](https://img.shields.io/badge/supported%20plotly.js%20version-2.6.3-blue)

We are currently in the process of writing a software paper on Plotly.NET. in the meantime, if you are using Plotly.NET for your research please cite the zenodo archive:

[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.6344285.svg)](https://doi.org/10.5281/zenodo.6344285)

Plotly.NET provides functions for generating and rendering plotly.js charts in **.NET** programming languages 📈🚀. 

### Table of contents 

- [Installation](#installation)
    - [For applications and libraries](#for-applications-and-libraries)
    - [For scripting](#for-scripting)
    - [For dotnet interactive notebooks](#for-dotnet-interactive-notebooks)
    - [Nightly builds](#getting-nightly-builds)
- [Documentation](#documentation)
    - [Getting started](#getting-started)
    - [Full library reference](#full-library-reference)
- [Develop](#develop)
    - [build](#build)
    - [docs](#docs)
- [Contributors](#contributors)
- [Library license](#library-license)

# Installation

The most recent Plotly.NET package is [![](https://img.shields.io/nuget/vpre/Plotly.NET)](https://www.nuget.org/packages/Plotly.NET/).

### For applications and libraries

 - dotnet CLI

```shell
dotnet add package Plotly.NET <version>
```

 - paket CLI

```shell
paket add Plotly.NET --version <version>
```

 - package manager

```shell
Install-Package Plotly.NET -Version <version>
```

Or add the package reference directly to your `.*proj` file:

```
<PackageReference Include="Plotly.NET" Version="<version>" />
```


### For scripting

You can include the package via an inline package reference:

```
#r "nuget: Plotly.NET, <version>"
```

### For dotnet interactive notebooks

You can use the same inline package reference as in script, but as an additional goodie, 
the interactive extensions for dotnet interactive have you covered for seamless chart rendering:

```
#r "nuget: Plotly.NET, <version>"
#r "nuget: Plotly.NET.Interactive, <version>"
```

<details><summary><h3>Getting nightly builds</h3><sub>[click 🖱️]</sub></summary>

The nightly builds are located on myget.org.

For your project:
```
dotnet new nugetconfig
dotnet nuget add source https://www.myget.org/F/plotly-net-nightly/api/v3/index.json
dotnet add package Plotly.NET --prerelease
```

Interactively:
```
#i "https://www.myget.org/F/plotly-net-nightly/api/v3/index.json"
#r "nuget:Plotly.NET.Interactive, *-*"
```

</details>

# Documentation

## Getting started

The landing page of our docs contains everything to get you started fast, check it out [📖 here](http://plotly.github.io/Plotly.NET/) 

## Full library reference

The API reference is available [📚 here](http://plotly.github.io/Plotly.NET/reference/index.html)

The documentation for this library is automatically generated (using FSharp.Formatting) from *.fsx and *.md files in the docs folder. If you find a typo, please submit a pull request!

# Development

_Note:_ The `release` and `prerelease` build targets assume that there is a `NUGET_KEY` environment variable that contains a valid Nuget.org API key.

### build

Check the [build project](https://github.com/plotly/Plotly.NET/blob/dev/build) to take a look at the  build targets. Here are some examples:

```shell
# Windows

# Build only
./build.cmd

# Full release buildchain: build, test, pack, build the docs, push a git tag, publish thze nuget package, release the docs
./build.cmd release

# The same for prerelease versions:
./build.cmd prerelease


# Linux/mac

# Build only
build.sh

# Full release buildchain: build, test, pack, build the docs, push a git tag, publísh the nuget package, release the docs
build.sh release

# The same for prerelease versions:
build.sh prerelease

```

### docs

The docs are contained in `.fsx` and `.md` files in the `docs` folder. To develop docs on a local server with hot reload, run the following in the root of the project:

```shell
# Windows
./build.cmd watchdocs

# Linux/mac
./build.sh watchdocs
```

## Contributors 

Plotly.NET is a community maintained open source projects. Big thanks to all contributors!

<a href="https://github.com/plotly/Plotly.NET/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=plotly/Plotly.NET" />
</a>

## Library license

The library is available under the [MIT license](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE).
