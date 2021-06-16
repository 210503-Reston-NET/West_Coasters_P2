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
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=TestEquipment.db").Options;
            seed();
        }
        [Fact]
        public async Task GeTAllEquipmentsShouldGetAllEquipments()
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
    }
}
