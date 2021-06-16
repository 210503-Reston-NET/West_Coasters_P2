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
    public class UserBLTest1
    {
        Mock<IUsersRepo> mockRepo;
        public UserBLTest1()
        {
            mockRepo = new Mock<IUsersRepo>();
        }
        [Fact]
        public async Task AddUserAsync()
        {
            mockRepo.Setup(x => x.AddUserAsync(It.IsAny<User>())).Returns
            (
                Task.FromResult(
                    new User(){
                        UserId = "abc"
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.AddUserAsync(new User());
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.UserId);
        }

        [Fact]
        public async Task UpdateUserAsync()
        {
            mockRepo.Setup(x => x.UpdateUserAsync(It.IsAny<User>())).Returns
            (
                Task.FromResult(
                    new User(){
                        UserId = "abc"
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.UpdateUserAsync(new User());
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.UserId);
        }

        [Fact]
        public async Task GetUserByIdAsync()
        {
            mockRepo.Setup(x => x.GetUserByIdAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new User(){
                        UserId = "abc"
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.GetUserByIdAsync("abc");
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.UserId);
        }

        [Fact]
        public async Task GetUserByEmailAsync()
        {
            mockRepo.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new User(){
                        UserId = "abc",
                        Email = "abc"
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.GetUserByEmailAsync("abc");
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.Email);
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            mockRepo.Setup(x => x.DeleteUserAsync(It.IsAny<User>())).Returns
            (
                Task.FromResult(
                    new User(){
                        UserId = "abc"
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.DeleteUserAsync(new User());
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.UserId);
        }

        [Fact]
        public async Task GetAllUsersAsync()
        {
            mockRepo.Setup(x => x.GetAllUsersAsync()).Returns
            (
                Task.FromResult(
                    new List<User>() {
                        new User(){
                            UserId = "abc"
                        }
                    }
                )
            );
            
            IUsersBL bl = new UsersBL(mockRepo.Object);
            var test = await bl.GetAllUsersAsync();
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test[0].UserId);
        }
    }
}