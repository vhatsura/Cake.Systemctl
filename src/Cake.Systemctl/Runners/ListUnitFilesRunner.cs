using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Models;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    /// <summary>
    ///     The runner for 'list-unit-files' command
    /// </summary>
    public class ListUnitFilesRunner : SystemctlOperationRunner<ListUnitFilesSettings>
    {
        public ListUnitFilesRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public List<UnitFile> UnitFiles { get; private set; }

        protected override void InternalRun(ListUnitFilesSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("list-unit-files");

            if (!string.IsNullOrWhiteSpace(settings.State)) arguments.Append($"--state={settings.State}");

            Run(settings, arguments, new ProcessSettings {RedirectStandardOutput = true, RedirectStandardError = true},
                Handle);
        }

        private void Handle(IProcess process)
        {
            var standardOutput = process.GetStandardOutput();

            UnitFiles = standardOutput
                .Select(line => line
                    .Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray()
                )
                .Select(s => new UnitFile
                    {
                        Name = s.ElementAtOrDefault(0),
                        State = s.ElementAtOrDefault(1)
                    }
                )
                .ToList();
        }
    }
}