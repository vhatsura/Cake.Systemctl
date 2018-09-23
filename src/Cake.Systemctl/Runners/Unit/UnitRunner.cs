using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners.Unit
{
    public abstract class UnitRunner : SystemctlRunner<UnitSettings>
    {
        protected UnitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected abstract string UnitCommand { get; }

        protected override void InternalRun(UnitSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append(UnitCommand);

            if (string.IsNullOrWhiteSpace(settings.UnitName))
            {
                throw new ArgumentNullException(nameof(settings.UnitName), "The name of unit should be specified");
            }

            builder.Append(settings.UnitName);

            Run(settings, builder);
        }
    }
}