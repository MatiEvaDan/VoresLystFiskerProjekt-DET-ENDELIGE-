using VoresLystFiskerPortal.Models;
using Microsoft.EntityFrameworkCore;
using VoresLystFiskerPortal.Data;
using Microsoft.Extensions.Hosting;

namespace VoresLystFiskerPortal.Persistence
{
    public class FishRepo : IFishRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public FishRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;

        }

        public async Task AddFishAsync(Fish fish)
        {
            await using var context = _contextFactory.CreateDbContext();
            await context.Fish.AddAsync(fish);
            await context.SaveChangesAsync();

        }

        public async Task DeleteFishAsync(int id)
        {

            await using var context = _contextFactory.CreateDbContext();
            var fish = await context.Fish.FirstOrDefaultAsync(f => f.FishId == id);

            if (fish != null)
                context.Remove(fish);
                await context.SaveChangesAsync();

        }
       
        public async Task UpdateFishAsync(int id, Fish _fish)
        {

            await using var context = _contextFactory.CreateDbContext();
            var fish = await context.Fish.FirstOrDefaultAsync(f => f.FishId == id);

            if (fish != null)
            {
                fish.FishLength = _fish.FishLength;
                fish.FishWeight = _fish.FishWeight;
                fish.FishType = _fish.FishType;
                fish.FishAmount = _fish.FishAmount;

                await context.SaveChangesAsync();
            }

        }
        public async Task<Fish> GetByIdFishAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Fish.FirstOrDefaultAsync(f => f.FishId == id);
        }

        public async Task<List<Fish>> GetAllFishAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Fish.ToListAsync();
        }

    }

}
