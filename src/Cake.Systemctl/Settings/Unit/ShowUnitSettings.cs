using System.Collections.Generic;

namespace Cake.Systemctl.Settings.Unit
{
    public class ShowUnitSettings : UnitSettings, IPropertyFilter
    {
        public IList<string> Properties { get; set; }
    }
}