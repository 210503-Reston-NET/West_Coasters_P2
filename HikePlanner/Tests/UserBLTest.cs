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
    public class UserBLTest
    {
        Mock<IUsersRepo> mockRepo;
        IUsersBL _bl;
        public UserBLTest()
        {
            mockRepo = new Mock<IUsersRepo>();
            mockRepo.Setup(x => x.GetUserByIdAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new User() {
                        UserId = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        Email = "goodday@gmail.com",
                        AddressId = 1,
                        Address = new Address {
                            Id = 1,
                            City = "123"
                        }
                    }
                )
            );

            _bl = new UsersBL(mockRepo.Object);
        }

        [Fact]
        public async Task GetUserByAsyncShouldReturnEmail()
        {
            var test = await _bl.GetUserByIdAsync("abc");
            string target = "goodday@gmail.com";
            Assert.NotNull(test);
            Assert.Equal(target, test.Email);
        }

        [Fact]
        public async Task GetUserByAsyncShouldReturnId()
        {
            var test = await _bl.GetUserByIdAsync("abc");
            string target = "9f0250da-ea47-4bcc-984e-a5c97b3a4872";
            Assert.NotNull(test);
            Assert.Equal(target, test.UserId);
        }

    }
}