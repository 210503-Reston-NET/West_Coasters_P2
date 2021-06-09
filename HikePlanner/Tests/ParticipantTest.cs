using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace Tests
{
    public class ParticipantTest
    {
        //Test valid foreign keys
        [Fact]
        public void ForeignKeyCreatorShouldNotBeEmpty()
        {
            Participant test = new Participant();
            Assert.Throws<ValidationException>(() => test.UserId = "");
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