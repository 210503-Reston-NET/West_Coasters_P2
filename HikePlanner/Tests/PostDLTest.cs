using DL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class PostDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public PostDLTest(){
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestPost.db").Options;
            seed();
        }

        [Fact]
        public async Task GetPostByIdAsync()
        {
            using(var context = new AppDBContext(options)){
                IPostRepo _repo = new PostRepo(context);
                int target = 1;
                Post test = await _repo.GetPostByIdAsync(target);
                Assert.Equal(1, test.Id);
            }
        }
        [Fact]
        public async Task GetAllPostsByTripIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IPostRepo _repo = new PostRepo(context);
                int target = 1;
                List<Post> test = await _repo.GetAllPostsByTripIdAsync(target);
                Assert.True(test.Count == 1);
                Assert.Equal(1, test[0].Id);
            }
        }

        [Fact]
        public async Task GetAllPostsAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IPostRepo _repo = new PostRepo(context);
                List<Post> test = await _repo.GetAllPostsAsync();
                Assert.True(test.Count == 1);
                Assert.Equal(1, test[0].Id);
            }
        }

        [Fact]
        public async Task AddNewPostAsync(){
            using(var context = new AppDBContext(options))
            {
                IPostRepo _repo = new PostRepo(context);
                int TripId = 1;
                int target = 2;
                Post newPost = new Post
                    {
                        Id = target,
                        Notes = "Great trip",
                        UserId = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        TripId = TripId
                    };
                await _repo.AddNewPostAsync(newPost);
                Post test = await _repo.GetPostByIdAsync(target);
                Assert.Equal(target, test.Id);
                var test1 = await _repo.GetAllPostsAsync();
                Assert.True(test1.Count == 2);
            }
        }

        [Fact]
        public async Task UpdatePostAsync()
        {
            using(var context = new AppDBContext(options))
            {
                IPostRepo _repo = new PostRepo(context);
                int target = 1;
                string targetValue = "wonderful trip";
                Post toUpdate = await _repo.GetPostByIdAsync(target);
                toUpdate.Notes = targetValue;
                await _repo.UpdatePostAsync(toUpdate);
                Post test = await _repo.GetPostByIdAsync(target);
                Assert.Equal(targetValue, test.Notes);
            }
        }

        [Fact]
        private void seed()
        {
            //this is an example of a using block
            using (var context = new AppDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Activities.AddRange(
                    new Activity {
                        Id = 1,
                        Name = "Tahoe Rim Activity one",
                        Notes = "Must pack your sweaters its gonna be cold weather",
                        TrailId = "128958",
                        TrailHead = "Nevada Trails Park",
                        Creator = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        Trips = new List<Trip>(){
                            new Trip {
                                Id = 1,
                                Creator = "lovelyPerson",
                                Distance = 2,
                                ActivityId = 1,
                                ChecklistId = 1,
                                Checklist = new Checklist {
                                    Id = 1
                                },
                                Posts = new List<Post>() {
                                    new Post
                                    {
                                        Id = 1,
                                        Notes = "Must pack your sweaters its gonna be cold weather",
                                        UserId = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                                        TripId = 1
                                    }
                                }
                            }
                        }
                    });

                context.SaveChanges();
            }
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            using (var context = new AppDBContext(options))
            {

                IPostRepo _repo = new PostRepo(context);
                int target = 1;
                Post toDelete = await _repo.GetPostByIdAsync(target);
                await _repo.DeletePostAsync(toDelete);
                List<Post> test = await _repo.GetAllPostsAsync();
                Assert.True(test.Count == 0);
                Assert.Empty(test);
            }
        }
    }
}
