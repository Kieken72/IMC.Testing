using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
{
    public class StringCalculator_Simple_Tests_001
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Simple_Tests_001()
        {
            _calulator = new StringCalulator();
        }
        [Fact]
        public void Add_With_Empty_String_Returns_Zero()
        {
            //Setup

            //Act
            var number = _calulator.Add("");

            //Assert
            Assert.Equal(0, number);
        }

        [Fact]
        public void Add_With_One_Number_Returns_Number()
        {
            //Setup

            //Act
            var number = _calulator.Add("5");

            //Assert
            Assert.Equal(5, number);
        }

        [Fact]
        public void Add_With_Two_Numbers_Returns_Number()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,5");

            //Assert
            Assert.Equal(10, number);
        }

        [Fact]
        public void Add_With_Three_Numbers_Returns_Number()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,5,5");

            //Assert
            Assert.Equal(15, number);
        }

        [Fact]
        public void Add_With_Invalid_String_Returns_Exception()
        {
            //Setup

            //Act
            Action act = () => _calulator.Add("hallo wereld");

            //Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
