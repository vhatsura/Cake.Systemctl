using Cake.Systemctl.Runners.Unit;
using Cake.Systemctl.Settings;

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
            var runner = new StartUnitRunner(Context.FileSystem, Context.Environment, Context.ProcessRunner,
                Context.Tools);

            runner.Run(settings);
        }

        /// <summary>
        ///     Stop (deactivate) unit.
        /// </summary>
        /// <param name="settings">The settings of unit to stop.</param>
        public void StopUnit(UnitSettings settings)
        {
            var runner = new StopUnitRunner(Context.FileSystem, Context.Environment, Context.ProcessRunner,
                Context.Tools);

            runner.Run(settings);
        }  
    }
}