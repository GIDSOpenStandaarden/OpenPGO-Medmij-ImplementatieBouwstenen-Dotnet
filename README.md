# This repository has been archived
Dear reader, The decision has been made to archive this repository. The reason is that the OpenPGO-Medmij-ImplementatieBouwstenen-Dotnet isn’t being used and has deferred maintenance including security vulnerabilities. If you desire to use this adapter, please contact GIDS: info@gidsopenstandaarden.org.

# Medmij dotnet
.NET implementation of the MedMij OpenPGO building blocks.
The Medmij for .Net git project is the .NET implementation of the MedMij OpenPGO building blocks.

#### Version Guidance

This library follows [Semantic Versioning](https://semver.org/).
The versions of the Afspraken set are mapped to the versions of the library as follows:

| Version Afsprakenset | Status | Version library |
|----------------------------|------------|-----------------|
| [Afsprakenset release 1.1] | Latest | 0.2.* |

[Afsprakenset release 1.1]: https://afsprakenstelsel.medmij.nl/display/PUBLIC/Afsprakenset+release+1.1

## Structure
It consists of 3 projects:
* `MedMij` - the library component. This can be included and used in .NET projects that acces MedMij data
* `MedMij.Xunit` - the unittests project
* `MedMij.Example` - the example project with working code for usage of the MedMij component

## Installation
First clone, restore and build the repo:
```shell
$ PATH_TO_CLONE=~/example/medmij-dotnet
$ git clone https://github.com/Zorgdoc/medmij-dotnet.git $PATH_TO_CLONE
Cloning into ...
...
$

$ dotnet restore
...

$ dotnet build
...
```

To run the Example project:

```shell
$ cd $PATH_TO_CLONE/MedMij.Example
$ dotnet run
...
```


To add a reference to your project

```shell
$ cd path_to_your_project/
$ dotnet add reference $PATH_TO_CLONE/MedMij
Reference `..\medmij-donet\MedMij\MedMij.csproj` added to the project.
```

## How to use

See the MedMij.Example project for working code examples for each scenario


## Testing

For the unittests is Xunit test framework used.

To run the tests use

```shell
$ cd $PATH_TO_CLONE/MedMij.Xunit
$ dotnet test
...
```

or

```shell
$ dotnet watch test
...
```
