using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Systemctl.Models;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    /// <summary>
    ///     The runner for 'list-unit-files' command
    /// </summary>
    public class ListUnitFilesRunner : SystemctlOperationRunner<ListUnitFilesSettings>
    {
        public ListUnitFilesRunner(ICakeContext context) : base(context)
        {
        }

        public List<UnitFile> UnitFiles { get; private set; }

        protected override ProcessArgumentBuilder GetArguments(ListUnitFilesSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("list-unit-files");

            if (!string.IsNullOrWhiteSpace(settings.State)) arguments.Append($"--state={settings.State}");

            return arguments;
        }

        protected override void Handle(IEnumerable<string> output)
        {
            UnitFiles = output
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