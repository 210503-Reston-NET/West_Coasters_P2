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
    public class ParticipantBLTest
    {
        Mock<ITripRepo> mockRepo;
        public ParticipantBLTest()
        {
            mockRepo = new Mock<ITripRepo>();
        }

        [Fact]
        public async Task AddNewParticipantAsync()
        {
            mockRepo.Setup(x => x.AddNewParticipantAsync(It.IsAny<Participant>())).Returns
            (
                Task.FromResult(
                    new Participant(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.AddNewParticipantAsync(new Participant());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task UpdateParticipantAsync()
        {
            mockRepo.Setup(x => x.UpdateParticipantAsync(It.IsAny<Participant>())).Returns
            (
                Task.FromResult(
                    new Participant(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.UpdateParticipantAsync(new Participant());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeleteParticipantAsync()
        {
            mockRepo.Setup(x => x.DeleteParticipantAsync(It.IsAny<Participant>())).Returns
            (
                Task.FromResult(
                    new Participant(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            await bl.DeleteParticipantAsync(new Participant());
            Assert.NotNull(new Participant());
        }

        [Fact]
        public async Task GetParticipantByIdAsync()
        {
            mockRepo.Setup(x => x.GetParticipantByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Participant(){
                        Id = 1
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetParticipantByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }
        [Fact]
        public async Task GetAllParticipantsByTripIdAsync()
        {
            mockRepo.Setup(x => x.GetAllParticipantsByTripIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new List<Participant>() {
                        new Participant(){
                            Id = 1
                        }
                    }
                )
            );
            
            ITripBL bl = new TripBL(mockRepo.Object);
            var test = await bl.GetAllParticipantsByTripIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

    }
}