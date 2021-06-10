using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface IPostBL
    {
        Task<Post> AddNewPostAsync(Post post);
        Task DeletePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<List<Post>> GetAllPostsByTripIdAsync(int tripId);
    }
}