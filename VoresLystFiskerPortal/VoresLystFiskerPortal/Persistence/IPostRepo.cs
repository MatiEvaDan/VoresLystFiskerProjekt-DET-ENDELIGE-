using VoresLystFiskerPortal.Models;

namespace VoresLystFiskerPortal.Persistence
{
    public interface IPostRepo
    {
        Task AddPostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetByIdPostAsync(int id);
        Task UpdatePostAsync(int id, Post _post);
        Task<List<Post>> GetFeedPostsAsync();
        Task<List<Post>> GetLeaderBoardWeigthAsync();
        Task<List<Post>> GetUserPostsAsync(string userId);
    }
}