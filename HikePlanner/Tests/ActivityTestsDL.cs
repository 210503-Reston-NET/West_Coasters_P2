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
    public class ActivityTestsDL
    {
        private readonly DbContextOptions<AppDBContext> options;
        public ActivityTestsDL(){
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestActivity.db").Options;
            seed();
        }

        [Fact]
        public async Task GetActivityByIdShouldReturnActivity(){
            using(var context = new AppDBContext(options)){
            ///await seed();
                  //Arrange
                    IActivityRepo _repo = new ActivityRepo(context);
                  //Act
                    Activity activity = 
                    await _repo.GetActivityByIdAsync(1);
                //Assert
                    Assert.Equal(1, activity.Id);
            }
        }
        [Fact]
        public async Task GetActivityByCreatorShouldReturnCreatorActivities()
        {
            using (var context = new AppDBContext(options))
            {
                //await seed();
                //Arrange
                IActivityRepo _repo = new ActivityRepo(context);
                //Act
                List<Activity> activity =
                await _repo.GetAllActivitisByCreatorAsync("9f0250da-ea47-4bcc-984e-a5c97b3a4872");
                //Assert
                Assert.Equal(1, activity[0].Id);
            }
        }
        [Fact]
        public async Task AddActivityShouldAddActivityAsync(){
            using(var context = new AppDBContext(options)){

                //Arrange
                IActivityRepo _repo = new ActivityRepo(context);
                //Act
                await _repo.AddNewActivityAsync
                (
                    new Activity("Cool Trail Hike","We are gonna have fun", "7890", "Trail Hike", "9f0250da-ea47-4bcc-984e-a5c97b3a4872")
                );
            }

        }

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
    }
}
