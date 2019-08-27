#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            solutionFilePath: "./cake.systemctl.sln",
                            title: "Cake.Systemctl",
                            repositoryOwner: "vhatsura",
                            repositoryName: "Cake.Systemctl",
                            shouldRunGitVersion: true,
                            shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

// BuildParameters.Tasks.DefaultTask.IsDependentOn(BuildParameters.Tasks.PublishMyGetPackagesTask.Task.Name);

Build.RunDotNetCore();