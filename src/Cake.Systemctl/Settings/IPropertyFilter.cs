using System.Collections.Generic;

namespace Cake.Systemctl.Settings
{
    public interface IPropertyFilter
    {
        /// <summary>
        /// Limit display to properties specified
        /// </summary>
        IList<string> Properties { get; }
    }
}