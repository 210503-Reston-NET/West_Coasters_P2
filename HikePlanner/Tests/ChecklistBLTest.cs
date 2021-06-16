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
    public class ChecklistBLTest
    {
        Mock<IChecklistRepo> mockRepo;
        public ChecklistBLTest()
        {
            mockRepo = new Mock<IChecklistRepo>();
        }

        [Fact]
        public async Task CreateNewChecklistAsync()
        {
            mockRepo.Setup(x => x.CreateNewChecklistAsync(It.IsAny<Checklist>())).Returns
            (
                Task.FromResult(
                    new Checklist(){
                        Id = 1,
                        Name = "abc"
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.CreateNewChecklistAsync(new Checklist());
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.Name);
        }

        [Fact]
        public async Task GetChecklistByIdAsync()
        {
            mockRepo.Setup(x => x.GetChecklistByIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new Checklist(){
                        Id = 1,
                        Name = "abc"
                    }
                )
            );

            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.GetChecklistByIdAsync(1);
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.Name);
        }

        [Fact]
        public async Task GetChecklistByUserIdAsync()
        {
            mockRepo.Setup(x => x.GetChecklistByUserIdAsync(It.IsAny<string>())).Returns
            (
                Task.FromResult(
                    new List<Checklist>(){
                        new Checklist(){
                            Id = 1,
                            Name = "abc"
                        }
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.GetChecklistByUserIdAsync("a");
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Name);
        }

        [Fact]
        public async Task GetAllChecklistsAsync()
        {
            mockRepo.Setup(x => x.GetAllChecklistsAsync()).Returns
            (
                Task.FromResult(
                    new List<Checklist>(){
                        new Checklist(){
                            Id = 1,
                            Name = "abc"
                        }
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.GetAllChecklistsAsync();
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Name);
        }
        [Fact]
        public async Task CreateNewChecklistItemAsync()
        {
            mockRepo.Setup(x => x.CreateNewChecklistItemAsync(It.IsAny<ChecklistItem>())).Returns
            (
                Task.FromResult(
                    new ChecklistItem(){
                        Id = 1,
                        ChecklistId = 1
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.CreateNewChecklistItemAsync(new ChecklistItem());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.ChecklistId);
        }

        [Fact]
        public async Task DeleteChecklistAsync()
        {
            mockRepo.Setup(x => x.DeleteChecklistAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(true)
            );

            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.DeleteChecklistAsync(1);
            Assert.True(test);
        }

        [Fact]
        public async Task DeleteChecklistItemAsync()
        {
            mockRepo.Setup(x => x.DeleteChecklistItemAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(true)
            );

            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.DeleteChecklistItemAsync(1);
            Assert.True(test);
        }

        [Fact]
        public async Task GetChecklistItemsByChecklistIdAsync()
        {
            mockRepo.Setup(x => x.GetChecklistItemsByChecklistIdAsync(It.IsAny<int>())).Returns
            (
                Task.FromResult(
                    new List<ChecklistItem>(){
                        new ChecklistItem{
                            Id = 1,
                            ChecklistId = 1
                        }
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.GetChecklistItemsByChecklistIdAsync(1);
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test[0].Id);
        }

        [Fact]
        public async Task UpdateChecklistAsync()
        {
            mockRepo.Setup(x => x.UpdateChecklistAsync(It.IsAny<Checklist>())).Returns
            (
                Task.FromResult(
                    new Checklist(){
                        Id = 1,
                        Name = "abc"
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.UpdateChecklistAsync(new Checklist());
            string target = "abc";
            Assert.NotNull(test);
            Assert.Equal(target, test.Name);
        }

        [Fact]
        public async Task UpdateChecklistItemAsync()
        {
            mockRepo.Setup(x => x.UpdateChecklistItemAsync(It.IsAny<ChecklistItem>())).Returns
            (
                Task.FromResult(
                    new ChecklistItem(){
                        Id = 1,
                        ChecklistId = 1
                    }
                )
            );
            
            IChecklistBL bl = new ChecklistBL(mockRepo.Object);
            var test = await bl.UpdateChecklistItemAsync(new ChecklistItem());
            int target = 1;
            Assert.NotNull(test);
            Assert.Equal(target, test.ChecklistId);
        }
    }
}