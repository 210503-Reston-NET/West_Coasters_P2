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
    public class AddressDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public AddressDLTest(){
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestAddress.db").Options;
            seed();
        }

        [Fact]
        public async Task GetAddressByIdShouldReturnAddress()
        {
            using(var context = new AppDBContext(options)){
                IAddressRepo _repo = new AddressRepo(context);
                int target = 1;
                Address test = await _repo.GetAddressByIdAsync(target);
                Assert.Equal(1, test.Id);
            }
        }

        [Fact]
        public async Task AddNewAddressAsync(){
            using(var context = new AppDBContext(options))
            {
                IAddressRepo _repo = new AddressRepo(context);
                IUsersRepo _UserRepo = new UsersRepo(context, _repo);

                int target = 3;
                string targetPerson = "KindPerson";

                User newUser = new User {
                        UserId = targetPerson,
                        Email = "goodday@outlook.com",
                        AddressId = 2,
                        Address = new Address {
                            Id = 2

                        }
                };
                await _UserRepo.AddUserAsync(newUser);
                User user = await _UserRepo.GetUserByIdAsync(targetPerson);
                Assert.Equal(targetPerson, user.UserId);

                Address newAddress = new Address
                    {
                        Id = target,
                        City = "Bellevue",
                    };

                await _repo.AddAddressAsync(targetPerson, newAddress);
                Address test = await _repo.GetAddressByIdAsync(target);
                Assert.Equal(target, test.Id);
            }
        }

        [Fact]
        public async Task UpdateAddressAsync()
        {
            using(var context = new AppDBContext(options))
            {
                IAddressRepo _repo = new AddressRepo(context);
                int target = 1;
                string targetValue = "Redmond";
                Address toUPdate = await _repo.GetAddressByIdAsync(target);
                toUPdate.City = targetValue;
                await _repo.UpdateAddressAysncAsync(toUPdate);
                Address test = await _repo.GetAddressByIdAsync(target);
                Assert.Equal(targetValue, test.City);
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
                context.Users.AddRange(
                    new User {
                        UserId = "lovelyPerson",
                        Email = "goodday@gmail.com",
                        AddressId = 1,
                        Address = new Address {
                            Id = 1,
                            City = "Seattle"
                        }
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

                IAddressRepo _repo = new AddressRepo(context);
                int target = 1;
                Address toDelete = await _repo.GetAddressByIdAsync(target);
                await _repo.DeleteAddressAsync(toDelete);
                var test = await _repo.GetAddressByIdAsync(target);
                Assert.Null(test);
            }
        }
    }
}
