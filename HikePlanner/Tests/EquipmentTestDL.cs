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
    public class EquipmentTestDL
    {
        private readonly DbContextOptions<AppDBContext> options;
        public EquipmentTestDL()
        {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=Test.db").Options;
        }
        [Fact]
        public async Task GeTAllEquipmentsShouldGetAllEquipments()
        {
            await seed();
            using (var context = new AppDBContext(options))
            {
                //Arrange
                IEquipmentRepo _repo = new EquipmentRepo(context);
                //Act
                var AllEquipements = await _repo.GetAllEquipmentsAsync();
                //Assert
                Assert.Equal(1, AllEquipements.Count);

            }
        }
        [Fact]
        public async Task AddEquipmentsShouldAddEquipmentAsync()
        {
            using (var context = new AppDBContext(options))
            {
                //Arrange
                IEquipmentRepo _repo = new EquipmentRepo(context);
                //Act
                await _repo.AddEquipmentAsync
                (
                    new Equipment("Day Pack", "20-30L Pack for day hikes")
                );
            }

        }

        private async Task seed()
        {
            //this is an example of a using block
            using (var context = new AppDBContext(options))
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
                await context.Equipments.AddRangeAsync(
                    new Equipment
                    {
                        Id = 1,
                        Name= "65L backpack",
                        Description= "65L pack- good for an overnighter to 2-3day trips",
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
