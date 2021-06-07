using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace Tests
{
    public class ChecklistTest
    {
        [Fact]
        public void ChecklistNameShouldNotBeEmpty()
        {
            Checklist test = new Checklist();
            Assert.Throws<ValidationException>(() => test.Name = "");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ChecklistTripIdShouldNotBeLessThanZero(int input)
        {
            Checklist test = new Checklist();
            Assert.Throws<ValidationException>(() => test.TripId = input);
        }

        [Fact]
        public void ChecklistShouldSetName()
        {
            Checklist test = new Checklist();
            test.Name = "name";
            Assert.Equal("name", test.Name);
        }

        [Fact]
        public void ChecklistShouldSetValidTripId()
        {
            Checklist test = new Checklist();
            test.TripId = 123;
            Assert.Equal(123, test.TripId);
        }

        [Fact]
        public void ChecklistShouldSetValidId()
        {
            Checklist test = new Checklist();
            test.Id= 123;
            Assert.Equal(123, test.Id);
        }
    }

    public class ChecklistItemTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ChecklistItemQuantityShouldNotBeLessThanZero(int input)
        {
            ChecklistItem test = new ChecklistItem();
            Assert.Throws<ValidationException>(() => test.Quantity = input);
        }

        [Fact]
        public void ChecklistItemShouldSetValidQuantity()
        {
            ChecklistItem test = new ChecklistItem();
            test.Quantity = 123;
            Assert.Equal(123, test.Quantity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ChecklistIdShouldNotBeLessThanZero(int input)
        {
            ChecklistItem test = new ChecklistItem();
            Assert.Throws<ValidationException>(() => test.ChecklistId = input);
        }

        [Fact]
        public void ChecklistItemShouldSetValidChecklistId()
        {
            ChecklistItem test = new ChecklistItem();
            test.ChecklistId = 123;
            Assert.Equal(123, test.ChecklistId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void EquipmentIdShouldNotBeLessThanZero(int input)
        {
            ChecklistItem test = new ChecklistItem();
            Assert.Throws<ValidationException>(() => test.EquipmentId = input);
        }

        [Fact]
        public void ChecklistItemShouldSetValidEquipmentId()
        {
            ChecklistItem test = new ChecklistItem();
            test.EquipmentId = 123;
            Assert.Equal(123, test.EquipmentId);
        }

        [Fact]
        public void ChecklistItemShouldSetValidId()
        {
            ChecklistItem test = new ChecklistItem();
            test.Id = 123;
            Assert.Equal(123, test.Id);
        }
    }
}
