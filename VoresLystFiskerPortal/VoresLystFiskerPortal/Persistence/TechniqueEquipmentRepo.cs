using VoresLystFiskerPortal.Models;
using Microsoft.EntityFrameworkCore;
using VoresLystFiskerPortal.Data;

namespace VoresLystFiskerPortal.Persistence
{
    public class TechniqueEquipmentRepo : ITechniqueEquipmentRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;


        public TechniqueEquipmentRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;

        }

        public async Task AddTechniqueEquipmentAsync(TechniqueEquipment techniqueEquipment)
        {
            await using var context = _contextFactory.CreateDbContext();
            await context.TechniqueEquipment.AddAsync(techniqueEquipment);
            await context.SaveChangesAsync();
        }


        public async Task<List<TechniqueEquipment>> GetAllTechniqueEquipmentAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.TechniqueEquipment.ToListAsync();
        }


    }
}
