using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace Tests
{
    public class ParticipantTest
    {
        [Fact]
        public void AcceptShouldReturnRightTrue()
        {
            Participant test = new Participant();
            test.Accept = true;
            Assert.True(test.Accept);
        }
        [Fact]
        public void AcceptShouldReturnRightFalse()
        {
            Participant test = new Participant();
            test.Accept = false;
            Assert.False(test.Accept);
        }

        //Test valid foreign keys
        [Fact]
        public void ForeignKeyCreatorShouldNotBeEmpty()
        {
            Participant test = new Participant();
            Assert.Throws<ValidationException>(() => test.UserId = "");
        }

        [Fact]
        public void UserIdShouldSetString()
        {
            Participant test = new Participant();
            test.UserId = "abc";
            Type target = typeof(string);
            Assert.Equal(test.UserId.GetType(), target);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ForeignKeyTripIdShouldNotLessThanZero(int input)
        {
            Participant test = new Participant();
            Assert.Throws<ValidationException>(() => test.TripId = input);
        }
        
        [Fact]
        public void ForeignKeyTripIdShouldReturnRightType()
        {
            Participant test = new Participant();
            test.TripId = 123;
            Assert.Equal(123, test.TripId);
        }   

        
    }
}