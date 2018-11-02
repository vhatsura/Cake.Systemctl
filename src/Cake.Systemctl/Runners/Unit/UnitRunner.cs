using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Systemctl.Settings.Unit;

namespace Cake.Systemctl.Runners.Unit
{
    public abstract class UnitRunner<TSettings> : SystemctlOperationRunner<TSettings>
        where TSettings : UnitSettings
    {
        protected UnitRunner(ICakeContext context) : base(context)
        {
        }

        protected abstract string UnitCommand { get; }

        protected override ProcessArgumentBuilder GetArguments(TSettings settings)
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