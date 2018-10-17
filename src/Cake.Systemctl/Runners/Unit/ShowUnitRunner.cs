using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Systemctl.Settings.Unit;

namespace Cake.Systemctl.Runners.Unit
{
    public class ShowUnitRunner : UnitRunner<ShowUnitSettings>
    {
        public ShowUnitRunner(ICakeContext context) : base(context)
        {
        }

        public IDictionary<string, string> Properties { get; private set; }
        
        protected override string UnitCommand => "show";

        protected override ProcessArgumentBuilder GetArguments(ShowUnitSettings settings)
        {
            var arguments = base.GetArguments(settings);

            var properties = settings.Properties
                ?.Where(p => !string.IsNullOrWhiteSpace(p))
                .ToList();
            
            if (properties?.Any() ?? false)
            {
                arguments.Append($"--property={string.Join(",", properties)}");
            }

            return arguments;
        }

        protected override void Handle(IEnumerable<string> output)
        {
            Properties = output
                .Select(o => o.Split('='))
                .ToDictionary(x => x.ElementAtOrDefault(0), x => x.ElementAtOrDefault(1));
        }
    }
}