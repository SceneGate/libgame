# Yarhl: Yet Another ROM Hacking Library [![GPL v3 License](https://img.shields.io/badge/license-GPL%20V3-blue.svg?style=flat)](http://www.gnu.org/copyleft/gpl.html)

![Yarhl Logo](https://raw.githubusercontent.com/SceneGate/Yarhl/master/docs/images/logo.png)

**Yarhl** is a library for *ROM Hacking* and fan-translation projects.
It provides a virtual file system, file format and format conversion features
and plugin support. It's built in C# / .NET and works in Windows, Linux and
Mac OS X.

| NuGet | [![Nuget](https://img.shields.io/nuget/v/Yarhl.svg)](https://www.nuget.org/packages/Yarhl) [![Nuget prerelease](https://img.shields.io/nuget/vpre/Yarhl.svg)](https://www.nuget.org/packages/Yarhl) |
| ----- | ------ |
| **Build & Test** | [![Build Status](https://dev.azure.com/SceneGate/Yarhl/_apis/build/status/SceneGate.Yarhl?branchName=master)](https://dev.azure.com/SceneGate/Yarhl/_build/latest?definitionId=1&branchName=master) |
| **Quality report** | [![Sonar Gate](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=alert_status)](https://sonarcloud.io/dashboard?id=yarhl) |
| **Coverage** | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=coverage)](https://sonarcloud.io/dashboard?id=yarhl) |
| **Project Best Practices** | [![CII Best Practices](https://bestpractices.coreinfrastructure.org/projects/2919/badge)](https://bestpractices.coreinfrastructure.org/projects/2919) |
| **Quality Details** | [![Maintainability](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=yarhl) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=bugs)](https://sonarcloud.io/dashboard?id=yarhl) [![Code smells](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=code_smells)](https://sonarcloud.io/dashboard?id=yarhl) [![Duplicated lines](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=yarhl) |
| **Code Stats** | [![Lines of code](https://sonarcloud.io/api/project_badges/measure?project=yarhl&metric=ncloc)](https://sonarcloud.io/dashboard?id=yarhl) |

## Documentation

Check our on-line API overview: [Mastering Yarhl](https://scenegate.github.io/Yarhl/articles/Mastering-Yarhl.html)
and the API documentation [here](https://scenegate.github.io/Yarhl/).

## Install

Yarhl is available on NuGet:

* [Yarhl](https://www.nuget.org/packages/Yarhl)
* [Yarhl.Media](https://www.nuget.org/packages/Yarhl.Media)

## Build

### Linux & Mac OS X

Requirements:
[*Mono*](http://www.mono-project.com/docs/getting-started/install/linux/).

1. Clone the repository.

2. Run `./build.sh`

### Windows

Requirements:
*Visual Studio* or
[*Xamarin Studio*](http://www.monodevelop.com/download/).

1. Clone the repository. You can use the
   [GitHub client](https://windows.github.com/)
   or the [command-line](https://git-scm.com/downloads).

2. Run `.\build.ps1`
