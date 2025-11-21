using System.Security.Principal;
using VoresLystFiskerPortal.Data;

namespace Lystfiskerportalen.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public DateTime DateAndTime { get; set; }
        public string PostImage { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public ICollection<TechniqueEquipment> TechniqueEquipments { get; set; }
        public ICollection<Fish> Fish { get; set; }

    }
}
