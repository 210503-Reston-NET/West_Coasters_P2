using Models;
using System;
using Xunit;
namespace Tests
{
    public class EquipmentModelTest
    {
        /// <summary>
        /// Test Equipment properties
        /// </summary>
        [Fact]
        public void NameShouldReturnRightName()
        {
            string name = "suncreen";
            Equipment test = new Equipment();

            test.Name = name;
            Assert.Equal(name, test.Name);
        }

        [Fact]
        public void DescriptionShouldReturnRightDescription()
        {
            string description = "good for your skin";
            Equipment test = new Equipment();

            test.Description = description;
            Assert.Equal(description, test.Description);
        }

        /// <summary>
        /// Test Equipment contructors
        /// </summary>
        /// 
        [Fact]
        public void ConstructWithNameOnlyShouldRetrunRigthName()
        {
            Equipment test = new Equipment("sunscreen");
            Assert.Equal("sunscreen", test.Name);
        }

        [Fact]
        public void ConstructWithNameAndDescriptionShouldReturnRightData()
        {
            Equipment test = new Equipment("sunscreen", "good for your skin");
            Assert.Equal("sunscreen", test.Name);
            Assert.Equal("good for your skin", test.Description);
        }

        [Fact]
        public void ConstructWithEquipmentObjectShouldReturnRightObject()
        {
            Equipment newEquip = new Equipment()
                {
                    Id = 1,
                    Name = "sunscreen",
                    Description = "good for your skin"
                };
            Equipment test = new Equipment(newEquip);
            Assert.NotNull(test);
            Assert.Equal(1, test.Id);
            Assert.Equal("sunscreen", test.Name);
        }

    }
}