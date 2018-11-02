using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl.Runners
{
    /// <summary>
    ///     The runner for 'daemon-reload' command
    /// </summary>
    public class DaemonReloadRunner : SystemctlOperationRunner<SystemctlOperationSettings>
    {
        public DaemonReloadRunner(ICakeContext context) : base(context)
        {
        }

        protected override ProcessArgumentBuilder GetArguments(SystemctlOperationSettings settings)
        {
            var arguments = new ProcessArgumentBuilder()
                .Append("daemon-reload");

            return arguments;
        }

        protected override void Handle(IEnumerable<string> standardOutput) { }
    }
}