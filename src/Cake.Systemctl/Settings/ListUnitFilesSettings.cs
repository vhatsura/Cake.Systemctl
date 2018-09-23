namespace Cake.Systemctl.Settings
{
    /// <summary>
    /// Settings for 'list-unit-files' command
    /// </summary>
    public class ListUnitFilesSettings: SystemctlSettings, IStateFilter
    {
        /// <inheritdoc/>
        public string State { get; set; }
    }
}