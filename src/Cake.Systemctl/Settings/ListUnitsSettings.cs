namespace Cake.Systemctl.Settings
{
    /// <summary>
    /// Settings for 'list-units' command
    /// </summary>
    public class ListUnitsSettings : SystemctlSettings, IStateFilter
    {
        /// <summary>
        /// true to also show inactive units and units which are following other units 
        /// </summary>
        public bool All { get; set; }
        
        /// <inheritdoc/>
        public string State { get; set; }
        
        /// <summary>
        /// A type of unit to filter
        /// </summary>
        public string Type { get; set; }
    }
}