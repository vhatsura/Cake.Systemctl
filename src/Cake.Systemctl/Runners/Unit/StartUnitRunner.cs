using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Systemctl.Runners.Unit
{
    public class StartUnitRunner : UnitRunner
    {
        public StartUnitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        protected override string UnitCommand => "start";
    }
}