using Models;
using System;
using Xunit;

namespace Tests
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

        [Fact]
        public void NameShouldNotSetNullData()
        {
            //Arrange
            User test = new User();
            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = "");
        }

        [Fact]
        public void EmailShouldSetValidData()
        {
            //Arrange
            string email = "Mike@gmail.com";
            User test = new User();

            //Act
            test.Email = email;

            //Assert
            Assert.Equal(email, test.Email);
        }

        [Fact]
        public void UserIdShouldSetString()
        {
            User test = new User();
            test.UserId = "abc";
            Type target = typeof(string);
            Assert.Equal(test.UserId.GetType(), target);
        }

        [Fact]
        public void EmailShouldSetString()
        {
            User test = new User();
            test.Email = "abc";
            Type target = typeof(string);
            Assert.Equal(test.Email.GetType(), target);
        }
    }
}
