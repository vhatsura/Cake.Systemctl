using Cake.Core;
using Cake.Systemctl.Settings.Unit;

namespace Cake.Systemctl.Runners.Unit
{
    public class StopUnitRunner : UnitRunner<UnitSettings>
    {
        public StopUnitRunner(ICakeContext context) : base(context)
        {
        }

        protected override string UnitCommand => "stop";
    }
}