using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cake.Common;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Systemctl.Models;
using Cake.Systemctl.Runners;
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
    public static partial class SystemctlAliases
    {
        /// <summary>
        /// List units that currently was loaded to memory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A list of units.</returns>
        public static List<Unit> ListUnits(this ICakeContext context) => ListUnits(context, new ListUnitsSettings());

        /// <summary>
        /// List units that currently was loaded to memory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings</param>
        /// <returns>A list of units.</returns>
        [CakeMethodAlias]
        public static List<Unit> ListUnits(this ICakeContext context, ListUnitsSettings settings)
        {
            var runner = new ListUnitsRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);

            runner.Run(settings);

            return runner.Units;
        }

        /// <summary>
        /// List unit files installed on the system.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A list of unit files</returns>
        [CakeMethodAlias]
        public static List<UnitFile> ListUnitFiles(this ICakeContext context) =>
            ListUnitFiles(context, new ListUnitFilesSettings());

        /// <summary>
        /// List unit files installed on the system.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings</param>
        /// <returns>A list of unit files.</returns>
        [CakeMethodAlias]
        public static List<UnitFile> ListUnitFiles(this ICakeContext context, ListUnitFilesSettings settings)
        {
            var runner = new ListUnitFilesRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);

            runner.Run(settings);

            return runner.UnitFiles;
        }
    }
}