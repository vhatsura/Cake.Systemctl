#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "../src",
                            rootDirectoryPath: "../",
                            solutionFilePath: "../cake.systemctl.sln",
                            title: "Cake.Systemctl",
                            repositoryOwner: "vhatsura",
                            repositoryName: "Cake.Systemctl",
                            shouldRunGitVersion: true,
                            shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

BuildParameters.Tasks.DefaultTask.IsDependentOn(BuildParameters.Tasks.PublishMyGetPackagesTask.Task.Name);

Build.RunDotNetCore();