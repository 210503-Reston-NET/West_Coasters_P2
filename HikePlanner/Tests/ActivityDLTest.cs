using DL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ActivityDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public ActivityDLTest(){
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestActivity.db").Options;
            seed();
        }

        [Fact]
        public async Task GetActivityByIdShouldReturnActivity()
        {
            using(var context = new AppDBContext(options)){
                IActivityRepo _repo = new ActivityRepo(context);
                int target = 1;
                Activity test = await _repo.GetActivityByIdAsync(target);
                Assert.Equal(1, test.Id);
            }
        }
        [Fact]
        public async Task GetActivityByCreatorShouldReturnCreatorActivities()
        {
            using (var context = new AppDBContext(options))
            {
                IActivityRepo _repo = new ActivityRepo(context);
                string target = "9f0250da-ea47-4bcc-984e-a5c97b3a4872";
                List<Activity> test = await _repo.GetAllActivitisByCreatorAsync(target);
                Assert.True(test.Count == 1);
                Assert.Equal(1, test[0].Id);
            }
        }

        [Fact]
        public async Task AddNewActivityAsync(){
            using(var context = new AppDBContext(options))
            {
                IActivityRepo _repo = new ActivityRepo(context);
                int target = 2;
                Activity newActivity = new Activity
                    {
                        Id = target,
                        Name = "Tahoe Rim Activity one",
                        Notes = "Must pack your sweaters its gonna be cold weather",
                        TrailId = "128958",
                        TrailHead = "Nevada Trails Park",
                        Creator = "9f0250da-ea47-4bcc-984e-a5c97b3a4872"
                    };
                await _repo.AddNewActivityAsync(newActivity);
                Activity test = await _repo.GetActivityByIdAsync(target);
                Assert.Equal(target, test.Id);
                var test1 = await _repo.GetAllActivitisAsync();
                Assert.True(test1.Count == 2);
            }
        }

        [Fact]
        public async Task UpdateActivityAsync()
        {
            using(var context = new AppDBContext(options))
            {
                IActivityRepo _repo = new ActivityRepo(context);
                int target = 1;
                string targetValue = "Mt Rannier";
                Activity toUPdate = await _repo.GetActivityByIdAsync(target);
                toUPdate.TrailHead = targetValue;
                await _repo.UpdateActivityAsync(toUPdate);
                Activity test = await _repo.GetActivityByIdAsync(target);
                Assert.Equal(targetValue, test.TrailHead);
            }
        }

        [Fact]
        private void seed()
        {
            //this is an example of a using block
            using (var context = new AppDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Activities.AddRange(
                    new Activity
                    {
                        Id = 1,
                        Name = "Tahoe Rim Activity one",
                        Notes = "Must pack your sweaters its gonna be cold weather",
                        TrailId = "128958",
                        TrailHead = "Nevada Trails Park",
                        Creator = "9f0250da-ea47-4bcc-984e-a5c97b3a4872"
                    }
                );
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            using (var context = new AppDBContext(options))
            {

                IActivityRepo _repo = new ActivityRepo(context);
                int target = 1;
                Activity toDelete = await _repo.GetActivityByIdAsync(target);
                await _repo.DeleteActivityAsync(toDelete);
                List<Activity> test = await _repo.GetAllActivitisAsync();
                Assert.True(test.Count == 0);
                Assert.Empty(test);
            }
        }
    }
}
