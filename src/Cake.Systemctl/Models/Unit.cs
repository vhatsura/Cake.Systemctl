namespace Cake.Systemctl.Models
{
    public class Unit
    {
        public string Name { get; set; }
        
        public string LoadState { get; set; }
        
        public string ActiveState { get; set; }
        
        public string SubState { get; set; }

        public string Description { get; set; }
    }
}