namespace Cake.Systemctl.Settings
{
    public interface IStateFilter
    {
        /// <summary>
        ///     A state of unit to filter
        /// </summary>
        string State { get; }
    }
}