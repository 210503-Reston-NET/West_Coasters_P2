using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> AddNewPostAsync(Post Post);
        Task<Post> UpdatePostAsync(Post Post);
        Task DeletePostAsync(Post Post);
    }
}