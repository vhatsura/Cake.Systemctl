# Cake.Systemctl

[![NuGet](https://img.shields.io/nuget/v/Cake.Systemctl.svg)](https://www.nuget.org/packages/Cake.Systemctl)
[![MyGet](https://img.shields.io/myget/cake-systemctl/vpre/Cake.Systemctl.svg?label=myget)](https://www.myget.org/gallery/cake-systemctl)

Cake AddIn for managing services with systemctl service manager

[![Build Status](https://dev.azure.com/vadimhatsura/cake.systemctl/_apis/build/status/vhatsura.Cake.Systemctl?&branchName=develop)](https://dev.azure.com/vadimhatsura/cake.systemctl/_build/latest?definitionId=1)
[![AppVeyor branch](https://img.shields.io/appveyor/ci/vhatsura/cake-systemctl/develop.svg)](https://ci.appveyor.com/project/vhatsura/cake-systemctl/branch/develop)  

## Table of Contents

1. [Documentation](https://github.com/vhatsura/Cake.Systemctl#documentation)
2. [Example](https://github.com/vhatsura/Cake.Systemctl#example)
3. [License](https://github.com/vhatsura/Cake.Systemctl#license)

## Documentation

You can read the latest documentation at [cakebuild.net](https://cakebuild.net/dsl/systemctl).

## Example

```cake
#addin Cake.Systemctl

Task("Start")
    .Description("Start (activate) unit")
    .Does(() =>
    {
        Systemctl.StartUnit(
            new UnitSettings { UnitName = "Example" }
        );
    });

Task("Stop")
    .Description("Stop (deactivate) unit")
    .Does(() =>
    {
        Systemctl.StopUnit(
            new UnitSettings { UnitName = "Example" }
        );
    });

Task("List-Units")
    .Description("List units that currently was loaded to memory")
    .Does(() =>
    {
        Systemctl.ListUnits(
            new ListUnitsSettings
            {
                All = true,
                Type = "service"
            }
        );
    });

Task("List-Unit-Files")
    .Description("List unit files installed on the system")
    .Does(() =>
    {
        Systemctl.ListUnitFiles(
            new ListUnitFilesSettings
            {
                State = "disabled"
            }
        );
    });

Task("Show")
    .Description("Show properties of the unit")
    .Does(() =>
    {
        Systemctl.ShowUnit(
            new ShowUnitSettings
            {
                UnitName = "Example",
                Properties = new List<string> { "LoadState", "ActiveState" }
            }
        )
    });
```

## License

Copyright © Vadim Hatsura and contributors.

Cake.Systemctl is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/vhatsura/Cake.Systemctl/blob/master/LICENSE).