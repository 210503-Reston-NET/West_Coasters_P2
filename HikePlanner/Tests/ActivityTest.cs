using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace Tests
{
    public class ActivityTest
    {
        //Test valid foreign keys
        [Fact]
        public void ForeignKeyCreatorShouldNotBeEmpty()
        {
            Activity test = new Activity();
            Assert.Throws<ValidationException>(() => test.Creator = "");
        }

        //Test valid name for activity
        [Fact]
        public void NameShouldReturnRightName()
        {
            Activity test = new Activity();
            test.Name = "Hiking";
            Assert.Equal("Hiking", test.Name);
        }

        [Fact]
        public void NameShouldNotBeEmpty()
        {
            Checklist test = new Checklist();
            Assert.Throws<ValidationException>(() => test.Name = "");
        }
    }
}