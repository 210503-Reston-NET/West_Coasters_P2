using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepo _postRepo;
        public PostBL(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<Post> AddNewPostAsync(Post post)
        {
            return await _postRepo.AddNewPostAsync(post);
        }

        public async Task DeletePostAsync(Post post)
        {
            await _postRepo.DeletePostAsync(post);
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            return await _postRepo.UpdatePostAsync(post);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _postRepo.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepo.GetPostByIdAsync(id);
        }

        public async Task<List<Post>> GetAllPostsByTripIdAsync(int tripId)
        {
            return await _postRepo.GetAllPostsByTripIdAsync(tripId);
        }
    }
}