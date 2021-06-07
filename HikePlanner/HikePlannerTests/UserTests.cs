using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace HikePlannerTests
{
    public class UserTests
    {
        [Theory]
        [InlineData("Auryn")]
        [InlineData("abCed.Jr")]
        [InlineData("Shin Jong Ou")]
        [InlineData("Something-hyphen")]
        public void NameShouldSetValidData(string input)
        {
            //Arrange
            User test = new User();

            //Act
            test.Name = input;

            //Assert
            Assert.Equal(input, test.Name);
        }
        [Theory]
        [InlineData("328ui")]
        [InlineData("esxcyuhbkj8")]
        public void NameShouldNotSetInvalidData(string input)
        {
            //Arrange
            User test = new User();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = input);
        }

        [Fact]
        public void NameShouldNotSetNullData()
        {
            //Arrange
            User test = new User();
            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = "");
        }
    }
}
