namespace VoresLystFiskerPortal.Models
{
    public class Fish
    {
        public int FishId { get; set; }
        public double FishLength { get; set; }
        public double FishWeight { get; set; }
        public string FishType { get; set; }
        public int FishAmount { get; set; }


        public int PostId { get; set; } // Foreign key
        public Post Post { get; set; }

    }

}
