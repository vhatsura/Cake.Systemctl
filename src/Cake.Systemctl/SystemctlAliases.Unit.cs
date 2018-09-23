using Cake.Core;
using Cake.Core.Annotations;
using Cake.Systemctl.Runners.Unit;
using Cake.Systemctl.Settings;

namespace Cake.Systemctl
{
    public static partial class SystemctlAliases
    {
        /// <summary>
        /// Start (activate) unit.
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
        /// Stop (deactivate) unit.
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
    }
}