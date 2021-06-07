using System;
using Xunit;
using Models;
namespace HikePlannerTests
{
    public class UserTests
    {
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
    }
}
