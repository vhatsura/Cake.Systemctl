using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cake.Common;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Systemctl.Models;
using Cake.Systemctl.Runners.Unit;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl
{
    /// <summary>
    /// Systemctl aliases.
    /// A set of aliases for <see cref="http://cakebuild.net">Cake Build</see> to help with
    /// <see cref="https://www.freedesktop.org/software/systemd/man/systemctl.html">systemctl</see> operations
    /// </summary>
    [CakeAliasCategory("Systemctl")]
    public static class SystemctlAliases
    {
        /// <summary>
        /// Start (activate) unit
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings of unit to start.</param>
        [CakeMethodAlias]
        public static void StartUnit(this ICakeContext context, UnitSettings settings)
        {
            var runner = new StartUnitRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            
            runner.Run(settings);
        }

        /// <summary>
        /// Stop (deactivate) unit
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings of unit to stop.</param>
        [CakeMethodAlias]
        public static void StopUnit(this ICakeContext context, UnitSettings settings)
        {
            var runner = new StopUnitRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            
            runner.Run(settings);
        }

        /// <summary>
        /// List units that currently was loaded to memory
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="all"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static List<Unit> ListUnits(this ICakeContext context, bool all = false, string state = null)
        {
            var arguments = new StringBuilder("list-units");
            
            if (all)
            {
                arguments.Append(" --all");
            }

            if (state != null)
            {
                arguments.Append($" --state={state}");
            }
           
            var process = context.StartAndReturnProcess(
                "systemctl",
                new ProcessSettings
                {
                    Arguments = arguments.ToString(),
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                });

            var standardOutput = process.GetStandardOutput();

            return standardOutput
                .Select(line => line
                    .Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray()
                )
                .Select(s => new Unit
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

        /// <summary>
        /// List unit files installed on the system
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="state"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static List<UnitFile> ListUnitFiles(this ICakeContext context, string state = null)
        {
            var arguments = new StringBuilder("list-unit-files");
            
            if (state != null)
            {
                arguments.Append($" --state={state}");
            }
           
            var process = context.StartAndReturnProcess(
                "systemctl",
                new ProcessSettings
                {
                    Arguments = arguments.ToString(),
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                });

            var standardOutput = process.GetStandardOutput();

            return standardOutput
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