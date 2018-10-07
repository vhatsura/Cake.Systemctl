using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    public abstract class SystemctlOperationRunner<TSettings> : Tool<TSettings>
        where TSettings : SystemctlOperationSettings
    {
        protected SystemctlOperationRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            Platform = environment.Platform;
        }

        private ICakePlatform Platform { get; }

        protected override string GetToolName()
        {
            return "systemctl";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {"systemctl"};
        }

        public void Run(TSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            if (!Platform.IsUnix()) throw new PlatformNotSupportedException();

            InternalRun(settings);
        }

        protected abstract void InternalRun(TSettings settings);
    }
}