using Cake.Core;
using Cake.Systemctl.Settings.Unit;

namespace Cake.Systemctl.Runners.Unit
{
    public class StartUnitRunner : UnitRunner<UnitSettings>
    {
        public StartUnitRunner(ICakeContext context) : base(context)
        {
        }

        protected override string UnitCommand => "start";
    }
}