using Lystfiskerportalen.Models;
using Microsoft.EntityFrameworkCore;
using VoresLystFiskerPortal.Data;

namespace Lystfiskerportalen.Persistence
{
    public class TechniqueEquipmentRepo : ITechniqueEquipmentRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TechniqueEquipmentRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public async Task AddTechniqueEquipmentAsync(TechniqueEquipment techniqueEquipment)
        {
            await _applicationDbContext.TechniqueEquipment.AddAsync(techniqueEquipment);
            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<List<TechniqueEquipment>> GetAllTechniqueEquipmentAsync()
        {
            return await _applicationDbContext.TechniqueEquipment.ToListAsync();
        }


    }
}
