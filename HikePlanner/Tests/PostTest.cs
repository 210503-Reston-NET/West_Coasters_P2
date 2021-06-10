using Models;
using System;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace Tests
{
    public class PostModelTest
    {
        //Test valid foreign keys
        [Fact]
        public void ForeignKeyCreatorShouldNotBeEmpty()
        {
            Post test = new Post();
            Assert.Throws<ValidationException>(() => test.UserId = "");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ForeignKeyTripIdShouldNotLessThanZero(int input)
        {
            Post test = new Post();
            Assert.Throws<ValidationException>(() => test.TripId = input);
        }
        [Fact]
        public void ForeignKeyTripIdShouldReturnRightType()
        {
            Post test = new Post();
            test.TripId = 123;
            Assert.Equal(123, test.TripId);
        }

        //Test note contents
        [Fact]
        public void NoteContentShouldNotBeEmpty()
        {
            Post test = new Post();
            Assert.Throws<ValidationException>(() => test.Notes = "");
        }

        //Test valid name for activity
        [Fact]
        public void NoteShouldReturnRightNote()
        {
            Activity test = new Activity();
            test.Name = "Welcome to join";
            Assert.Equal("Welcome to join", test.Name);
        }
    }
}