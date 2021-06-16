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
    public class EquipmentBLTest
    {
        Mock<IEquipmentRepo> mockRepo;
        public EquipmentBLTest()
        {
            mockRepo = new Mock<IEquipmentRepo>();
        }
        [Fact]
        public async Task AddEquipmentAsync()
        {
            mockRepo.Setup(x => x.AddEquipmentAsync(It.IsAny<Equipment>())).Returns
            (
                Task.FromResult(
                    new Equipment(){
                        Id = 1
                    }
                )
            );
            
            IEquipmentBL bl = new EquipmentBL(mockRepo.Object);
            var test = await bl.AddEquipmentAsync(new Equipment());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }
        
        [Fact]
        public async Task UpdateEquipmentAsync()
        {
            mockRepo.Setup(x => x.UpdateEquipmentAsync(It.IsAny<Equipment>())).Returns
            (
                Task.FromResult(
                    new Equipment(){
                        Id = 1
                    }
                )
            );
            
            IEquipmentBL bl = new EquipmentBL(mockRepo.Object);
            var test = await bl.UpdateEquipmentAsync(new Equipment());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task GetEquipmentByIdAsync()
        {
            mockRepo.Setup(x => x.GetEquipmentByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Equipment(){
                        Id = 1
                    }
                )
            );
            
            IEquipmentBL bl = new EquipmentBL(mockRepo.Object);
            var test = await bl.GetEquipmentByIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Id);
        }

        [Fact]
        public async Task DeleteParticipantAsync()
        {
            mockRepo.Setup(x => x.DeleteEquipmentAsync(It.IsAny<Equipment>())).Returns
            (
                Task.FromResult(
                    new Equipment(){
                        Id = 1
                    }
                )
            );
            
            IEquipmentBL bl = new EquipmentBL(mockRepo.Object);
            await bl.DeleteEquipmentAsync(new Equipment());
            Assert.NotNull(new Equipment());
        }

        [Fact]
        public async Task GetAllEquipmentsAsync()
        {
            mockRepo.Setup(x => x.GetAllEquipmentsAsync()).Returns
            (
                Task.FromResult(
                    new List<Equipment>() {
                        new Equipment(){
                            Id = 1
                        }
                    }
                )
            );
            
            IEquipmentBL bl = new EquipmentBL(mockRepo.Object);
            var test = await bl.GetAllEquipmentsAsync();
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.Count);
        }
    }
}