namespace Cake.Systemctl.Settings.Unit
{
    /// <summary>
    ///     Settings for commands with unit
    /// </summary>
    public class UnitSettings : SystemctlOperationSettings
    {
        /// <summary>
        ///     The name of unit
        /// </summary>
        public string UnitName { get; set; }
    }
}