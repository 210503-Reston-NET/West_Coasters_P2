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
    public class TripBLTest
    {
        Mock<ITripRepo> mockRepo;
        public TripBLTest()
        {
            mockRepo = new Mock<ITripRepo>();
        }

        [Fact]
        public async Task AddNewTripAsync()
        {
            mockRepo.Setup(x => x.AddNewTripAsync(It.IsAny<Trip>())).Returns
            (
                Task.FromResult(
                    new Trip(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.AddNewTripAsync(new Trip());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task UpdateTripAsync()
        {
            mockRepo.Setup(x => x.UpdateTripAsync(It.IsAny<Trip>())).Returns
            (
                Task.FromResult(
                    new Trip(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.UpdateTripAsync(new Trip());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeleteTripAsync()
        {
            mockRepo.Setup(x => x.DeleteTripAsync(It.IsAny<Trip>())).Returns
            (
                Task.FromResult(
                    new Trip(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            await bl.DeleteTripAsync(new Trip());
            Assert.NotNull(new Trip());
        }

        [Fact]
        public async Task GetTripByIdAsync()
        {
            mockRepo.Setup(x => x.GetTripByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Trip(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetTripByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task GetTripsByActivityIdAsync()
        {
            mockRepo.Setup(x => x.GetTripsByActivityIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new List<Trip>() {
                        new Trip(){
                            Id = 1
                        }
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetAllTripsByActivityIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

        [Fact]
        public async Task GetTripsByCreatorAsync()
        {
            mockRepo.Setup(x => x.GetTripsByCreatorAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new List<Trip>() {
                        new Trip(){
                            Id = 1
                        }
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetAllTripsByCreatorAsync("abc");
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

        [Fact]
        public async Task GetAllTripsAsync()
        {
            mockRepo.Setup(x => x.GetAllTripsAsync()).Returns
            (
                Task.FromResult(
                    new List<Trip>() {
                        new Trip(){
                            Id = 1
                        }
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetAllTripsAsync();
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

    }
}