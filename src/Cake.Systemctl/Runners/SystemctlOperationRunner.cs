using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Exceptions;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    public abstract class SystemctlOperationRunner<TSettings> : Tool<TSettings>
        where TSettings : SystemctlOperationSettings
    {
        protected SystemctlOperationRunner(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner,
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

            var arguments = GetArguments(settings);

            Run(settings, arguments, new ProcessSettings {RedirectStandardOutput = true, RedirectStandardError = true},
                Handle);
        }

        protected abstract ProcessArgumentBuilder GetArguments(TSettings settings);

        private void Handle(IProcess process)
        {
            var exitCode = process.GetExitCode();
            var errorOutput = process.GetStandardError().ToList();
            var output = process.GetStandardOutput().ToList();

            if (errorOutput.Any())
            {
                throw new SystemctlException(exitCode, errorOutput);
            }
            
            Handle(output);
        }

        protected abstract void Handle(IEnumerable<string> standardOutput);
    }
}