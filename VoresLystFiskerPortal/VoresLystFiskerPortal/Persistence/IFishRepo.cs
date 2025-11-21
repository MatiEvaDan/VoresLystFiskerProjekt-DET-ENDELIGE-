using VoresLystFiskerPortal.Models;

namespace VoresLystFiskerPortal.Persistence
{
    public interface IFishRepo
    {
        Task AddFishAsync(Fish fish);
        Task DeleteFishAsync(int id);
        Task<List<Fish>> GetAllFishAsync();
        Task<Fish> GetByIdFishAsync(int id);
        Task UpdateFishAsync(int id, Fish _fish);
    }
}