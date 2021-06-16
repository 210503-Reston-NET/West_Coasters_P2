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
    public class UsersRepoTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public UsersRepoTest() {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=Test.db").Options;
        }
        
        [Fact]
        public async Task GetById()
        {
            using (var context = new AppDBContext(options))
            {
                
                await SeedAsync();

                IUsersRepo _repo = new UsersRepo(context, new AddressRepo(context));

                User result = await _repo.GetUserByIdAsync("9f0250da-ea47-4bcc-984e-a5c97b3a4872");
                
                Assert.Equal("9f0250da-ea47-4bcc-984e-a5c97b3a4872", result.UserId);
            }
        }
        [Fact]
        public async Task GetUserByEmail()
        {
            using (var context = new AppDBContext(options))
            {
                
                await SeedAsync();

                IUsersRepo _repo = new UsersRepo(context, new AddressRepo(context));

                User result = await _repo.GetUserByEmailAsync("goodday@gmail.com");
                
                Assert.Equal("goodday@gmail.com", result.Email);
            }
        }
        [Fact]
        public async Task GetAll()
        {
            using (var context = new AppDBContext(options))
            {
                
                await SeedAsync();

                IUsersRepo _repo = new UsersRepo(context, new AddressRepo(context));

                List<User> result = await _repo.GetAllUsersAsync();
                Assert.NotNull(result);
                Assert.Equal("goodday@gmail.com", result[0].Email);
            }
        }

        [Fact]
        public async Task Update()
        {
            using (var context = new AppDBContext(options))
            {
                
                await SeedAsync();

                IUsersRepo _repo = new UsersRepo(context, new AddressRepo(context));
                var toUpdate =  new User {
                        UserId = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        Email = "goodday@outlook.com",
                        AddressId = 1,
                        Address = new Address {
                            Id = 1,
                            City = "123"
                        }
                    };

                await _repo.UpdateUserAsync(toUpdate);
                User result = await _repo.GetUserByIdAsync("9f0250da-ea47-4bcc-984e-a5c97b3a4872");
                Assert.NotNull(result);
                Assert.Equal("goodday@outlook.com", result.Email);
            }
        }

        [Fact]
        public async Task AddNew()
        {
            await SeedAsync();
            using (var context = new AppDBContext(options))
            {
                IUsersRepo _repo = new UsersRepo(context, new AddressRepo(context));
                var toAdd =  new User {
                        UserId = "123332425235325353252",
                        Email = "goodday@outlook.com",
                        AddressId = 2,
                        Address = new Address {
                            Id = 2,
                            City = "123"
                        }
                    };
                await _repo.AddUserAsync(toAdd);
                User result = await _repo.GetUserByIdAsync("123332425235325353252");
                Assert.NotNull(result);
                Assert.Equal("goodday@outlook.com", result.Email);
            }
        }
        
        [Fact]
        public async Task SeedAsync()
        {
            using (var context = new AppDBContext(options))
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
                await context.Users.AddRangeAsync(
                    new User {
                        UserId = "9f0250da-ea47-4bcc-984e-a5c97b3a4872",
                        Email = "goodday@gmail.com",
                        AddressId = 1,
                        Address = new Address {
                            Id = 1,
                            City = "123"
                        }
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}