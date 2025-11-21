using VoresLystFiskerPortal.Models;
using Microsoft.EntityFrameworkCore;
using VoresLystFiskerPortal.Data;

namespace VoresLystFiskerPortal.Persistence
{
    public class FishRepo : IFishRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FishRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public async Task AddFishAsync(Fish fish)
        {
            await _applicationDbContext.Fish.AddAsync(fish);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteFishAsync(int id)
        {

            var fish = await _applicationDbContext.Fish
                .FirstOrDefaultAsync(f => f.FishId == id);

            if (fish != null)
                _applicationDbContext.Remove(fish);
            await _applicationDbContext.SaveChangesAsync();

        }

        public async Task UpdateFishAsync(int id, Fish _fish)
        {

            var fish = await _applicationDbContext.Fish
                .FirstOrDefaultAsync(f => f.FishId == id);

            if (fish != null)
            {
                fish.FishLength = _fish.FishLength;
                fish.FishWeight = _fish.FishWeight;
                fish.FishType = _fish.FishType;
                fish.FishAmount = _fish.FishAmount;

                await _applicationDbContext.SaveChangesAsync();
            }

        }
        public async Task<Fish> GetByIdFishAsync(int id)
        {
            return await _applicationDbContext.Fish
                .FirstOrDefaultAsync(f => f.FishId == id);
        }

        public async Task<List<Fish>> GetAllFishAsync()
        {
            return await _applicationDbContext.Fish.ToListAsync();
        }

    }

}
