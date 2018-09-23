using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Systemctl.Runners.Unit
{
    public class StopUnitRunner : UnitRunner
    {
        public StopUnitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected override string UnitCommand => "stop";
    }
}