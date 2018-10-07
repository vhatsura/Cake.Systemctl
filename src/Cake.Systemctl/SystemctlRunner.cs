using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Systemctl.Models;
using Cake.Systemctl.Runners;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl
{
    public partial class SystemctlRunner
    {
        private ICakeContext Context { get; }
        
        public SystemctlRunner(ICakeContext context)
        {
            Context = context;
        }
        
        /// <summary>
        ///     List units that currently was loaded to memory.
        /// </summary>
        /// <returns>A list of units.</returns>
        public List<Unit> ListUnits()
        {
            return ListUnits(new ListUnitsSettings());
        }

        /// <summary>
        ///     List units that currently was loaded to memory.
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <returns>A list of units.</returns>
        public List<Unit> ListUnits(ListUnitsSettings settings)
        {
            var runner = new ListUnitsRunner(Context.FileSystem, Context.Environment, Context.ProcessRunner,
                Context.Tools);

            runner.Run(settings);

            return runner.Units;
        }

        /// <summary>
        ///     List unit files installed on the system.
        /// </summary>
        /// <returns>A list of unit files</returns>
        public List<UnitFile> ListUnitFiles()
        {
            return ListUnitFiles(new ListUnitFilesSettings());
        }

        /// <summary>
        ///     List unit files installed on the system.
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <returns>A list of unit files.</returns>
        [CakeMethodAlias]
        public List<UnitFile> ListUnitFiles(ListUnitFilesSettings settings)
        {
            var runner = new ListUnitFilesRunner(Context.FileSystem, Context.Environment, Context.ProcessRunner,
                Context.Tools);

            runner.Run(settings);

            return runner.UnitFiles;
        }
    }
}