using Xunit;
using System.Linq;
using DL;
using BL;
using System.Collections.Generic;
using Models;
using System;
using Moq;
using System.Threading.Tasks;

namespace Tests
{
    public class PostBLTest
    {
        Mock<IPostRepo> mockRepo;
        public PostBLTest()
        {
            mockRepo = new Mock<IPostRepo>();
        }

        [Fact]
        public async Task AddNewPostAsync()
        {
            mockRepo.Setup(x => x.AddNewPostAsync(It.IsAny<Post>())).Returns
            (
                Task.FromResult(
                    new Post(){
                        Id = 1
                    }
                )
            );
            
            IPostBL bl = new PostBL(mockRepo.Object);
            var test = await bl.AddNewPostAsync(new Post());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task UpdatePostAsync()
        {
            mockRepo.Setup(x => x.UpdatePostAsync(It.IsAny<Post>())).Returns
            (
                Task.FromResult(
                    new Post(){
                        Id = 1
                    }
                )
            );
            
            IPostBL bl = new PostBL(mockRepo.Object);
            var test = await bl.UpdatePostAsync(new Post());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeletePostAsync()
        {
            mockRepo.Setup(x => x.DeletePostAsync(It.IsAny<Post>())).Returns
            (
                Task.FromResult(
                    new Post(){
                        Id = 1
                    }
                )
            );
            
            IPostBL bl = new PostBL(mockRepo.Object);
            await bl.DeletePostAsync(new Post());
            Assert.NotNull(new Post());
        }

        [Fact]
        public async Task GetPostByIdAsync()
        {
            mockRepo.Setup(x => x.GetPostByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Post(){
                        Id = 1
                    }
                )
            );
            
            IPostBL bl = new PostBL(mockRepo.Object);
            var test = await bl.GetPostByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }
        [Fact]
        public async Task GetAllPostsByTripIdAsync()
        {
            mockRepo.Setup(x => x.GetAllPostsByTripIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new List<Post>() {
                        new Post(){
                            Id = 1
                        }
                    }
                )
            );
            
            IPostBL bl = new PostBL(mockRepo.Object);
            var test = await bl.GetAllPostsByTripIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

    }
}