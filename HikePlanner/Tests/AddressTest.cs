using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace Tests
{
    public class AddressTest
    {
        [Fact]
        public void StreetShouldSetString()
        {
            Address test = new Address();
            test.Street = "abc";
            Type target = typeof(string);
            Assert.Equal(test.Street.GetType(), target);
        }

        [Fact]
        public void CityShouldSetString()
        {
            Address test = new Address();
            test.City = "abc";
            Type target = typeof(string);
            Assert.Equal(test.City.GetType(), target);
        }

        [Fact]
        public void StateShouldSetString()
        {
            Address test = new Address();
            test.State = "abc";
            Type target = typeof(string);
            Assert.Equal(test.State.GetType(), target);
        }
    }
}