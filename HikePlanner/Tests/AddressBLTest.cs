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
    public class AddressBLTest
    {
        Mock<IAddressRepo> mockRepo;
        public AddressBLTest()
        {
            mockRepo = new Mock<IAddressRepo>();
        }

        [Fact]
        public async Task AddAddressAsync()
        {
            mockRepo.Setup(x => x.AddAddressAsync(It.IsAny<string>(),It.IsAny<Address>())).Returns
            (
                Task.FromResult(
                    new Address(){
                        Id = 1
                    }
                )
            );
            
            IAddressBL bl = new AddressBL(mockRepo.Object);
            var test = await bl.AddAddressAsync("abc", new Address());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task UpdateAddressAysncAsync()
        {
            mockRepo.Setup(x => x.UpdateAddressAysncAsync(It.IsAny<Address>())).Returns
            (
                Task.FromResult(
                    new Address(){
                        Id = 1
                    }
                )
            );
            
            IAddressBL bl = new AddressBL(mockRepo.Object);
            var test = await bl.UpdateAddressAysncAsync(new Address());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeleteAddressAsync()
        {
            mockRepo.Setup(x => x.DeleteAddressAsync(It.IsAny<Address>())).Returns
            (
                Task.FromResult(
                    new Address(){
                        Id = 1
                    }
                )
            );
            
            IAddressBL bl = new AddressBL(mockRepo.Object);
            await bl.DeleteAddressAsync(new Address());
            Assert.NotNull(new Address());
        }

        [Fact]
        public async Task GetAddressByIdAsync()
        {
            mockRepo.Setup(x => x.GetAddressByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Address(){
                        Id = 1
                    }
                )
            );
            
            IAddressBL bl = new AddressBL(mockRepo.Object);
            var test = await bl.GetAddressByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }
    }
}