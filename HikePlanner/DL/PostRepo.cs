using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class PostRepo : IPostRepo
    {
        private readonly AppDBContext _context;
        public PostRepo(AppDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get a list of post 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts
                .AsNoTracking()
                .Select(post => post)
                .ToListAsync();
        }

        /// <summary>
        /// Get a list of Posts by tripId
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetAllPostsByTripIdAsync(int tripId)
        {
            return await _context.Posts
                .AsNoTracking()
                .Where(obj => obj.TripId == tripId)
                .Select(post => post)
                .ToListAsync();
        }

        /// <summary>
        /// Get Post object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        /// <summary>
        /// Add new Post object in db
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<Post> AddNewPostAsync(Post post)
        {
            Post addedPost = _context.Posts.Add(post).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return addedPost;
        }
        
        /// <summary>
        /// Update Post object in db
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<Post> UpdatePostAsync(Post post)
        {
            Post updated = _context.Posts.Update(post).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }

        /// <summary>
        /// Delete Post object in db
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task DeletePostAsync(Post post)
        {
            Post toBeDeleted = _context.Posts.AsNoTracking().First(obj => obj.Id == post.Id);
            _context.Posts.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }  

    }
}