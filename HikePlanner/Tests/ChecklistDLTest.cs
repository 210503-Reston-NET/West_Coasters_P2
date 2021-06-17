using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DL;
using System.Threading.Tasks;

namespace Tests
{
    public class ChecklistDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public ChecklistDLTest() {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestChecklist.db").Options;
            Seed();
        } 
        [Fact]
        public async Task GetChecklistByIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                var test = await _repo.GetChecklistByIdAsync(1);
                int target = 1;
                Assert.Equal(target, test.Id);
            }
        }

        [Fact]
        public async Task GetChecklistItemByIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                var test = await _repo.GetChecklistItemByIdAsync(1);
                int target = 1;
                Assert.Equal(target, test.Equipment.Id);
            }
        }

        [Fact]
        public async Task GetChecklistItemsByChecklistIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                var test = await _repo.GetChecklistItemsByChecklistIdAsync(1);
                Assert.NotNull(test);
                Assert.True(test.Count == 2);
            }
        }
        [Fact]
        public async Task GetAllChecklistsAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                var test = await _repo.GetAllChecklistsAsync();
                Assert.NotNull(test);
                Assert.True(test.Count == 1);
            }
        }

        [Fact]
        public async Task CreateNewChecklistAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                string target = "cba";
                int targetId = 2;
                var toAdd = new Checklist {
                        Id = targetId,
                        Name = target,
                        ChecklistItems = new List<ChecklistItem>(){
                            new ChecklistItem  {
                                Id = 3,
                                ChecklistId = 2,
                                EquipmentId = 3,
                                Equipment = new Equipment {
                                    Id = 3
                                }
                            }
                        }
                    };
                
                await _repo.CreateNewChecklistAsync(toAdd);
                var test = await _repo.GetChecklistByIdAsync(targetId);
                
                Assert.NotNull(test);
                Assert.Equal(targetId, test.Id);
                Assert.Equal(target, test.Name);
            }
        }

        [Fact]
        public async Task UpdateChecklistAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                string target = "cba";
                int targetId = 1;
                var toUpdate =  new Checklist {
                    Id = targetId,
                    Name = target
                };
                await _repo.UpdateChecklistAsync(toUpdate);
                var test = await _repo.GetChecklistByIdAsync(targetId);
                
                Assert.NotNull(test);
                Assert.Equal(targetId, test.Id);
                Assert.Equal(target, test.Name);
            }
        }

        [Fact]
        public async Task CreateNewChecklistItemAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                int targetChecklist = 1;
                int targetId = 4;
                int target = 4;

                var toAddItem =  new ChecklistItem {
                    Id = targetId,
                    ChecklistId = targetChecklist,
                    EquipmentId = target,
                    Equipment = new Equipment {
                        Id = target
                    }
                };

                var checklist = await _repo.GetChecklistByIdAsync(targetChecklist);
                checklist.ChecklistItems.Append(await _repo.CreateNewChecklistItemAsync(toAddItem));

                var test = await _repo.GetChecklistItemByIdAsync(targetId);
                
                Assert.NotNull(test);
                Assert.Equal(targetId, test.Id);
                Assert.Equal(target, test.EquipmentId);
            }
        }

        [Fact]
        public async Task UpdateChecklistItemAsync()
        {
            using (var context = new AppDBContext(options))
            {
                IChecklistRepo _repo = new ChecklistRepo(context);
                int target = 2;
                int targetId = 1;
                var toUpdate =  new ChecklistItem {
                    Id = targetId,
                    ChecklistId = 1,
                    EquipmentId = target
                };
                await _repo.UpdateChecklistItemAsync(toUpdate);
                var test = await _repo.GetChecklistItemByIdAsync(targetId);
                
                Assert.NotNull(test);
                Assert.Equal(targetId, test.Id);
                Assert.Equal(target, test.EquipmentId);
            }
        }

        [Fact]
        public void Seed()
        {
            using (var context = new AppDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Checklists.AddRange(
                    new Checklist {
                        Id = 1,
                        Name = "ABC",
                        ChecklistItems = new List<ChecklistItem>(){
                            new ChecklistItem  {
                                Id = 1,
                                ChecklistId = 1,
                                EquipmentId = 1,
                                Equipment = new Equipment {
                                    Id = 1
                                }
                            },
                            new ChecklistItem {
                                Id = 2,
                                ChecklistId = 1,
                                EquipmentId = 2,
                                Equipment = new Equipment {
                                    Id = 2
                                }
                            }
                        }
                    }
                );
                context.SaveChanges();context.SaveChanges();
            }
        }

        [Fact]
        public async Task DeleteChecklistAsync()
        {
            using (var context = new AppDBContext(options))
            {
                int targetId = 1;
                IChecklistRepo _repo = new ChecklistRepo(context);
                bool test = await _repo.DeleteChecklistAsync(targetId);
                Assert.True(test);
            }
        }

        [Fact]
        public async Task DeleteChecklistItemAsync()
        {
            using (var context = new AppDBContext(options))
            {
                int targetId = 2;
                IChecklistRepo _repo = new ChecklistRepo(context);
                bool test = await _repo.DeleteChecklistItemAsync(targetId);
                Assert.True(test);
            }
        }

    }
}