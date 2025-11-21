namespace Lystfiskerportalen.Models
{
    public class TechniqueEquipment
    {
        public int TechniqueEquipmentId { get; set; }
        public string FishingTechnique { get; set; }
        public string HookType { get; set; }
        public string HookName { get; set; }


        public int PostId { get; set; } // Foreign key
        public Post Post { get; set; }

    }
}
