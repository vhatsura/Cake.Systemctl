namespace Cake.Systemctl.Models
{
    /// <summary>
    ///     Represents an unit file.
    /// </summary>
    public class UnitFile
    {
        /// <summary>
        ///     The name of unit file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The state of unit file
        /// </summary>
        public string State { get; set; }
    }
}