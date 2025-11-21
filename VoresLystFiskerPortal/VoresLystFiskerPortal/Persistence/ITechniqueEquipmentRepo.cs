using VoresLystFiskerPortal.Models;

namespace VoresLystFiskerPortal.Persistence
{
    public interface ITechniqueEquipmentRepo
    {
        Task AddTechniqueEquipmentAsync(TechniqueEquipment techniqueEquipment);
        Task<List<TechniqueEquipment>> GetAllTechniqueEquipmentAsync();
    }
}