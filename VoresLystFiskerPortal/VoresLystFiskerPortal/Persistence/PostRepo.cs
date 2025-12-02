using VoresLystFiskerPortal.Models;
using Microsoft.EntityFrameworkCore;
using VoresLystFiskerPortal.Data;

namespace VoresLystFiskerPortal.Persistence
{
    public class PostRepo : IPostRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public async Task AddPostAsync(Post post)
        {
            await _applicationDbContext.Posts.AddAsync(post);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {

            var post = await _applicationDbContext.Posts
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post != null)
                _applicationDbContext.Remove(post);
            await _applicationDbContext.SaveChangesAsync();

        }

        public async Task UpdatePostAsync(int id, Post _post)
        {

            var post = await _applicationDbContext.Posts
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post != null)
            {
                post.DateAndTime = _post.DateAndTime;
                post.PostImage = _post.PostImage;
                post.Location = _post.Location;
                post.Description = _post.Description;

                await _applicationDbContext.SaveChangesAsync();
            }

        }
        public async Task<Post> GetByIdPostAsync(int id)
        {
            return await _applicationDbContext.Posts
                .FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _applicationDbContext.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetLeaderBoardWeigthAsync()
        {
            return await _applicationDbContext.Posts
                .Include(p => p.User)                 
                .Include(p => p.Fish)                 
                .Include(p => p.TechniqueEquipments)                                   
                .OrderByDescending(p => p.Fish.Any() ? p.Fish.Max(f => f.FishWeight) : 0)
                .Take(10) 
                .ToListAsync();
        }

        public async Task<List<Post>> GetFeedPostsAsync()
        {
            return await _applicationDbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Fish)
                .Include(p => p.TechniqueEquipments)
                .OrderByDescending(p => p.DateAndTime)
                .ToListAsync();
        }
        public async Task<List<Post>> GetUserPostsAsync(string userId)
        {
            // userId er nu en string (GUID)
            return await _applicationDbContext.Posts
                // Vi bruger Post-objektets UserId-egenskab, som holder fremmednøglen til ApplicationUser.Id
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .Include(p => p.Fish)
                .Include(p => p.TechniqueEquipments)
                .OrderByDescending(p => p.DateAndTime)
                .ToListAsync();
        }





    }
}

