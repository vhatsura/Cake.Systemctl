using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    public abstract class SystemctlRunner<TSettings> : Tool<TSettings>
        where TSettings : SystemctlSettings
    {
        private ICakePlatform Platform { get; }
        
        protected SystemctlRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            Platform = environment.Platform;
        }

        protected override string GetToolName() => "systemctl";
        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "systemctl" };

        public void Run(TSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            
            if (!Platform.IsUnix())
            {
                throw new PlatformNotSupportedException();
            }
            
            InternalRun(settings);
        }

        protected abstract void InternalRun(TSettings settings);
    }
}