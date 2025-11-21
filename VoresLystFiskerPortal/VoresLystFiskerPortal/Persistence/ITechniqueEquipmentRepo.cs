using Lystfiskerportalen.Models;

namespace Lystfiskerportalen.Persistence
{
    public interface ITechniqueEquipmentRepo
    {
        Task AddTechniqueEquipmentAsync(TechniqueEquipment techniqueEquipment);
        Task<List<TechniqueEquipment>> GetAllTechniqueEquipmentAsync();
    }
}