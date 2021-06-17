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
    public class TripDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public TripDLTest() {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestTrips.db").Options;
            Seed();
        } 

        [Fact]
        public async Task GetTripByIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 2;
                Trip test = await _repo.GetTripByIdAsync(target);
                Assert.Equal(target, test.Id);
            }
        }

        [Fact]
        public async Task GetAllTripsAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                List<Trip> test = await _repo.GetAllTripsAsync();
                Assert.NotNull(test);
                Assert.True(test.Count == 2);
            }
        }

        [Fact]
        public async Task GetTripsByActivityIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 1;
                List<Trip> test = await _repo.GetTripsByActivityIdAsync(target);
                Assert.NotNull(test);
                Assert.True(test.Count == 2);
            }
        }

        [Fact]
        public async Task GetTripsByCreatorAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                string target = "lovelyPerson";
                List<Trip> test = await _repo.GetTripsByCreatorAsync(target);
                Assert.NotNull(test);
                Assert.True(test.Count == 1);
            }
        }

        [Fact]
        public async Task GetAllParticipantsByTripIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 1;
                List<Participant> test = await _repo.GetAllParticipantsByTripIdAsync(target);
                Assert.NotNull(test);
                Assert.True(test.Count == 1);
            }
        }

        [Fact]
        public async Task GetParticipantByIdAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 1;
                Participant test = await _repo.GetParticipantByIdAsync(target);
                Assert.Equal(target, test.Id);
            }
        }

        [Fact]
        public async Task UpdateParticipantAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 1;
                bool targetToChange = true;
                Participant toUpdate = await _repo.GetParticipantByIdAsync(target);
                toUpdate.Accept = targetToChange;
                await _repo.UpdateParticipantAsync(toUpdate);
                Participant test = await _repo.GetParticipantByIdAsync(target);
                Assert.Equal(target, test.Id);
                Assert.Equal(targetToChange, test.Accept);
            }
        }

        [Fact]
        public async Task UpdateTripAsync()
        {
            using (var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 2;
                string targetToChange = "coolPerson";
                Trip toUpdate = await _repo.GetTripByIdAsync(target);
                toUpdate.Creator = targetToChange;
                await _repo.UpdateTripAsync(toUpdate);
                Trip test = await _repo.GetTripByIdAsync(target);
                Assert.Equal(target, test.Id);
                Assert.Equal(targetToChange, test.Creator);
            }
        }

        [Fact]
        public async Task AddNewTripAsync(){
            using(var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 3;
                int targetValue = 3;
                Trip newTrip = new Trip {
                    Id = target,
                    Creator = "lovelyPerson",
                    Distance = 2,
                    ActivityId = 1,
                    ChecklistId = targetValue,
                    Checklist = new Checklist {
                        Id = targetValue
                    }
                };
                await _repo.AddNewTripAsync(newTrip);
                Trip test = await _repo.GetTripByIdAsync(target);
                Assert.NotNull(test);
                Assert.Equal(target, test.Id);
                Assert.Equal(targetValue, test.ChecklistId);
                
            }
        }

        [Fact]
        public async Task AddNewParticipantAsync(){
            using(var context = new AppDBContext(options))
            {
                ITripRepo _repo = new TripRepo(context);
                int target = 2;
                string targetPeson = "hiking lover";
                Participant newPerson = new Participant {
                    Id = target,
                    TripId = 1,
                    UserId = targetPeson,
                    User = new User {
                        UserId = targetPeson,
                        AddressId = 2,
                        Address = new Address {
                            Id = 2
                        }
                    }
                };
                await _repo.AddNewParticipantAsync(newPerson);
                Participant test = await _repo.GetParticipantByIdAsync(target);
                Assert.NotNull(test);
                Assert.Equal(target, test.Id);
                Assert.Equal(targetPeson, test.UserId);
            }
        }

        [Fact]
        public void Seed()
        {
            using (var context = new AppDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Activities.AddRange(
                    new Activity {
                        Id = 1,
                        Name = "Tahoe Rim Activity one",
                        Notes = "Must pack your sweaters its gonna be cold weather",
                        TrailId = "128958",
                        TrailHead = "Nevada Trails Park",
                        Creator = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        Trips = new List<Trip>(){
                            new Trip {
                                Id = 1,
                                Creator = "lovelyPerson",
                                Distance = 2,
                                ActivityId = 1,
                                ChecklistId = 1,
                                Checklist = new Checklist {
                                    Id = 1
                                },
                                Participants = new List<Participant>() {
                                    new Participant {
                                        Id = 1,
                                        TripId = 1,
                                        UserId = "teamplayer",
                                        User = new User {
                                            UserId = "teamplayer",
                                            AddressId = 1,
                                            Address = new Address {
                                                Id = 1
                                            }
                                        }
                                    }
                                }
                            },
                            new Trip {
                                Id = 2,
                                Creator = "kindFolk",
                                Distance = 2,
                                ActivityId = 1,
                                ChecklistId = 2,
                                Checklist = new Checklist {
                                    Id = 2
                                }
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task DeleteParticipantAsync()
        {
            using (var context = new AppDBContext(options))
            {
                int target = 1;
                int tripId = 1;
                ITripRepo _repo = new TripRepo(context);
                Participant toDelete = await _repo.GetParticipantByIdAsync(target);
                await _repo.DeleteParticipantAsync(toDelete);
                List<Participant> test = await _repo.GetAllParticipantsByTripIdAsync(tripId);
                Assert.True(test.Count == 0);
                Assert.Empty(test);
            }
        }

        [Fact]
        public async Task DeleteTripAsync()
        {
            using (var context = new AppDBContext(options))
            {
                int target = 2;
                ITripRepo _repo = new TripRepo(context);
                Trip toDelete = await _repo.GetTripByIdAsync(target);
                await _repo.DeleteTripAsync(toDelete);
                List<Trip> test = await _repo.GetAllTripsAsync();
                Assert.NotNull(test);
                Assert.True(test.Count == 1);
            }
        }
    }
}