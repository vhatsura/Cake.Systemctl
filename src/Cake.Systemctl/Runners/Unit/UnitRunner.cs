using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners.Unit
{
    public abstract class UnitRunner : SystemctlOperationRunner<UnitSettings>
    {
        protected UnitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected abstract string UnitCommand { get; }

        protected override ProcessArgumentBuilder GetArguments(UnitSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append(UnitCommand);

            if (string.IsNullOrWhiteSpace(settings.UnitName))
                throw new ArgumentNullException(nameof(settings.UnitName), "The name of unit should be specified");

            arguments.Append(settings.UnitName);

            return arguments;
        }

        protected override void Handle(IEnumerable<string> output)
        {
            
        }
    }
}