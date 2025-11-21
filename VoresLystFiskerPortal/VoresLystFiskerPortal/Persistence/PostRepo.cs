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

    }
}

