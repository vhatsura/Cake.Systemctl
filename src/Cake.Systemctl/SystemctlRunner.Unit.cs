using System.Collections.Generic;
using Cake.Systemctl.Runners.Unit;
using Cake.Systemctl.Settings.Unit;

namespace Cake.Systemctl
{
    public partial class SystemctlRunner
    {
        /// <summary>
        ///     Start (activate) unit.
        /// </summary>
        /// <param name="settings">The settings of unit to start.</param>
        public void StartUnit(UnitSettings settings)
        {
            var runner = new StartUnitRunner(Context);

            runner.Run(settings);
        }

        /// <summary>
        ///     Stop (deactivate) unit.
        /// </summary>
        /// <param name="settings">The settings of unit to stop.</param>
        public void StopUnit(UnitSettings settings)
        {
            var runner = new StopUnitRunner(Context);

            runner.Run(settings);
        }

        /// <summary>
        ///     Show properties of the unit
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <returns>A dictionary of property names and values of unit</returns>
        public IDictionary<string, string> ShowUnit(ShowUnitSettings settings)
        {
            var runner = new ShowUnitRunner(Context);

            runner.Run(settings);

            return runner.Properties;
        }
    }
}