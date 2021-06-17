using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Xunit;
using System.ComponentModel.DataAnnotations;
namespace Tests
{
    public class TripTest
    {
        //Test valid Date input for startDate
        //Test valid Date input for endDate
        //Test past date for startDate or endDate
        [Fact]
        public void StartDateShouldReturnDateAndTime()
        {
            DateTime inputTime = DateTime.Parse("8:00 AM");
            DateTime inputDate = new DateTime(2021, 6, 8);
            DateTime startDate = new DateTime(inputDate.Year, inputDate.Month, inputDate.Day,
                          inputTime.Hour, inputTime.Minute, inputTime.Second);
            
            Trip test = new Trip();
            DateTime actual = new DateTime(2021, 6, 8, 8, 0, 0);
            test.StartDate = startDate;
            Assert.Equal(actual, test.StartDate);
        }
        

        //Test input for distance, not be < 0
        [Fact]
        public void DistanceShouldReturnValidValue()
        {
            Trip test = new Trip();
            test.Distance = 10;
            Assert.Equal(10, test.Distance);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void DistanceShouldNotReturnValueLessThanZero(int input)
        {
            Trip test = new Trip();
            Assert.Throws<ValidationException>(() => test.Distance = input);
        }
        
        //Test valid foreign keys
        [Fact]
        public void ForeignKeyCreatorShouldNotBeEmpty()
        {
            Trip test = new Trip();
            Assert.Throws<ValidationException>(() => test.Creator = "");
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ForeignKeyActivityIdShouldNotLessThanZero(int input)
        {
            Trip test = new Trip();
            Assert.Throws<ValidationException>(() => test.ActivityId = input);
        }

        [Fact]
        public void UserIdShouldSetString()
        {
            Trip test = new Trip();
            test.Creator = "abc";
            Type target = typeof(string);
            Assert.Equal(test.Creator.GetType(), target);
        }
    }
}