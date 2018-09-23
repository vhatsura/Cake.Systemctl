namespace Cake.Systemctl.Models
{
    /// <summary>
    ///     Represents a unit.
    /// </summary>
    public class Unit
    {
        /// <summary>
        ///     The name of unit
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Reflects whether the unit definition was properly loaded.
        /// </summary>
        public string LoadState { get; set; }

        /// <summary>
        ///     The high-level unit activation state.
        /// </summary>
        public string ActiveState { get; set; }

        /// <summary>
        ///     The low-level unit activation state.
        /// </summary>
        public string SubState { get; set; }

        /// <summary>
        ///     The description of unit.
        /// </summary>
        public string Description { get; set; }
    }
}