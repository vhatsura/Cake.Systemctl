# Cake.Systemctl

[![Build status](https://ci.appveyor.com/api/projects/status/c07g64c90p9frh90/branch/master?svg=true)](https://ci.appveyor.com/project/vhatsura/sourcelyzer/branch/master)
[![Build Status](https://dev.azure.com/vadimhatsura/cake.systemctl/_apis/build/status/vhatsura.Cake.Systemctl?&branchName=develop)](https://dev.azure.com/vadimhatsura/cake.systemctl/_build/latest?definitionId=1)
[![NuGet Badge](https://buildstats.info/nuget/Cake.Systemctl)](https://www.nuget.org/packages/Cake.Systemctl)
[![MyGet](https://img.shields.io/myget/cake-systemctl/vpre/Cake.Systemctl.svg?label=myget)](https://www.myget.org/gallery/cake-systemctl)

An addin for the Cake Build System to manage services via systemctl service manager.

## Table of Contents

1. [Documentation](https://github.com/vhatsura/Cake.Systemctl#documentation)
2. [Examples](https://github.com/vhatsura/Cake.Systemctl#examples)
    - [List unit files](https://github.com/vhatsura/Cake.Systemctl#list-unit-files)
    - [List units](https://github.com/vhatsura/Cake.Systemctl#list-units)
    - [Work with unit](https://github.com/vhatsura/Cake.Systemctl#work-with-unit)
        - [Start unit](https://github.com/vhatsura/Cake.Systemctl#start-unit)
        - [Stop unit](https://github.com/vhatsura/Cake.Systemctl#stop-unit)
        - [Show unit properties](https://github.com/vhatsura/Cake.Systemctl#show-unit-properties)
    - [Daemon reload](https://github.com/vhatsura/Cake.Systemctl#daemon-reload)
3. [License](https://github.com/vhatsura/Cake.Systemctl#license)

## Documentation

You can read the latest documentation at [cakebuild.net](https://cakebuild.net/dsl/systemctl).

## Examples

Add Cake.Systemctl support to you cake script

```cake
#addin Cake.Systemctl
```

### List unit files

```cake
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
```

### List units

```cake
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
```

### Work with unit

#### Start unit

```cake
Task("Start")
    .Description("Start (activate) unit")
    .Does(() =>
    {
        Systemctl.StartUnit(
            new UnitSettings { UnitName = "Example" }
        );
    });
```

#### Stop Unit

```cake
Task("Stop")
    .Description("Stop (deactivate) unit")
    .Does(() =>
    {
        Systemctl.StopUnit(
            new UnitSettings { UnitName = "Example" }
        );
    });
```

#### Show unit properties

```cake
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

### Daemon reload

```cake
Task("Reload-Daemon-OnDemand")
    .Description("Reload systemd daemon if it's neccessary")
    .Does(() =>
    {
        var properties = Systemctl.ShowUnit(
            new ShowUnitSettings
            {
                UnitName = "Example",
                Properties = new List<string> { "NeedDaemonReload" }
            }
        );

        if (properties.TryGetValue("NeedDaemonReload", out var need)
            && need.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Systemctl.DaemonReload();
        }
    });
```

## License

Copyright © Vadim Hatsura and contributors.

Cake.Systemctl is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/vhatsura/Cake.Systemctl/blob/master/LICENSE).
