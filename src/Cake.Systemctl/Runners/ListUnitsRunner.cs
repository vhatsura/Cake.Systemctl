using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    /// <summary>
    /// The runner for 'list-units' command
    /// </summary>
    public class ListUnitsRunner : SystemctlRunner<ListUnitsSettings>
    {
        public List<Models.Unit> Units { get; private set; }

        public ListUnitsRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected override void InternalRun(ListUnitsSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("list-units");

            if (settings.All)
            {
                arguments.Append("--all");
            }

            if (!string.IsNullOrWhiteSpace(settings.State))
            {
                arguments.Append($"--state={settings.State}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Type))
            {
                arguments.Append($"--type={settings.Type}");
            }
            
            Run(settings, arguments, new ProcessSettings {RedirectStandardOutput = true, RedirectStandardError = true},
                Handle);
        }

        private void Handle(IProcess process)
        {
            var standardOutput = process.GetStandardOutput();

            Units = standardOutput
                .Select(line => line
                    .Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray()
                )
                .Select(s => new Models.Unit
                    {
                        Name = s.ElementAtOrDefault(0),
                        LoadState = s.ElementAtOrDefault(1),
                        ActiveState = s.ElementAtOrDefault(2),
                        SubState = s.ElementAtOrDefault(3),
                        Description = s.ElementAtOrDefault(4)
                    }
                )
                .ToList();
        }
    }
}