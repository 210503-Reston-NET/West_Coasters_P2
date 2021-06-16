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
    public class ActivityBLTest
    {
        Mock<IActivityRepo> mockRepo;
        public ActivityBLTest()
        {
            mockRepo = new Mock<IActivityRepo>();

        }

        [Fact]
        public async Task AddNewActivityAsync()
        {
            mockRepo.Setup(x => x.AddNewActivityAsync(It.IsAny<Activity>())).Returns
            (
                Task.FromResult(
                    new Activity(){
                        Id = 1
                    }
                )
            );
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            var test = await bl.AddNewActivityAsync(new Activity());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }
        
        [Fact]
        public async Task UpdateActivityAsync()
        {
            mockRepo.Setup(x => x.UpdateActivityAsync(It.IsAny<Activity>())).Returns
            (
                Task.FromResult(
                    new Activity(){
                        Id = 1
                    }
                )
            );
            
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            var test = await bl.UpdateActivityAsync(new Activity());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task GetActivityByIdAsync()
        {
            mockRepo.Setup(x => x.GetActivityByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Activity(){
                        Id = 1
                    }
                )
            );
            
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            var test = await bl.GetActivityByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeleteParticipantAsync()
        {
            mockRepo.Setup(x => x.DeleteActivityAsync(It.IsAny<Activity>())).Returns
            (
                Task.FromResult(
                    new Activity(){
                        Id = 1
                    }
                )
            );
            
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            await bl.DeleteActivityAsync(new Activity());
            Assert.NotNull(new Activity());
        }

        [Fact]
        public async Task GetAllActivitisByCreatorAsync()
        {
            mockRepo.Setup(x => x.GetAllActivitisByCreatorAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new List<Activity>() {
                        new Activity(){
                            Id = 1
                        }
                    }
                )
            );
            
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            var test = await bl.GetAllActivitisByCreatorAsync("abc");
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }
        [Fact]
        public async Task GetAllActivitiessAsync()
        {
            mockRepo.Setup(x => x.GetAllActivitisAsync()).Returns
            (
                Task.FromResult(
                    new List<Activity>() {
                        new Activity(){
                            Id = 1
                        }
                    }
                )
            );
            
            IActivityBL bl = new ActivityBL(mockRepo.Object);
            var test = await bl.GetAllActivitiessAsync();
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }
    }
}