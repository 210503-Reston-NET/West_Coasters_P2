using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Xunit;

namespace Tests
{
    public class EquipmentDLTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public EquipmentDLTest()
        {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestEquipment.db").Options;
            seed();
        }
        [Fact]
        public async Task GetAllEquipmentsAsync()
        {
            //await seed();
            using (var context = new AppDBContext(options))
            {
                //Arrange
                IEquipmentRepo _repo = new EquipmentRepo(context);
                //Act
                var AllEquipements = await _repo.GetAllEquipmentsAsync();
                //Assert
                Assert.Equal(1, AllEquipements[0].Id);

            }
        }
        [Fact]
        public async Task AddNewEquipmentAsync(){
            using(var context = new AppDBContext(options))
            {
                
                IEquipmentRepo _repo = new EquipmentRepo(context);
                int target = 2;
                Equipment newEquipment = new Equipment {
                    Id = target,
                    Name = "Day Pack",
                    Description = "20-30L Pack for day hikes"
                };
                await _repo.AddEquipmentAsync(newEquipment);
                Equipment test = await _repo.GetEquipmentByIdAsync(target);
                Assert.Equal(target, test.Id);
                var test1 = await _repo.GetAllEquipmentsAsync();
                Assert.True(test1.Count == 2);
            }
        }

        [Fact]
        public async Task UpdateEquipmentAsync()
        {
            using(var context = new AppDBContext(options))
            {
                IEquipmentRepo _repo = new EquipmentRepo(context);
                int target = 1;
                string targetValue = "Hiking boots";
                Equipment toUPdate = await _repo.GetEquipmentByIdAsync(target);
                toUPdate.Name = targetValue;
                await _repo.UpdateEquipmentAsync(toUPdate);
                Equipment test = await _repo.GetEquipmentByIdAsync(target);
                Assert.Equal(targetValue, test.Name);
            }
        }

        
        private void seed()
        {
            //this is an example of a using block
            using (var context = new AppDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Equipments.AddRange(
                    new Equipment
                    {
                        Id = 1,
                        Name= "65L backpack",
                        Description= "65L pack- good for an overnighter to 2-3day trips",
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

                IEquipmentRepo _repo = new EquipmentRepo(context);
                int target = 1;
                Equipment toDelete = await _repo.GetEquipmentByIdAsync(target);
                await _repo.DeleteEquipmentAsync(toDelete);
                List<Equipment> test = await _repo.GetAllEquipmentsAsync();
                Assert.True(test.Count == 0);
                Assert.Empty(test);
            }
        }

    }
}
