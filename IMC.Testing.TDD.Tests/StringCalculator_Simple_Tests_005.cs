using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
{
    public class StringCalculator_Simple_Tests_005
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Simple_Tests_005()
        {
            _calulator = new StringCalulator();
        }

        [Fact]
        public void Add_With_Negative_Numbers_Returns_Exception()
        {
            //Setup

            //Act
            Action act = () => _calulator.Add("-10,10,10");

            //Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Contains("negatives not allowed", exception.Message);
            Assert.Contains("-10", exception.Message);
        }


        [Fact]
        public void Add_With_Multiple_Negative_Numbers_Returns_Exception()
        {
            //Setup

            //Act
            Action act = () => _calulator.Add("-10,-20,10");

            //Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Contains("negatives not allowed", exception.Message);
            Assert.Contains("-10", exception.Message);
            Assert.Contains("-20", exception.Message);
        }
    }
}
