using System;
using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
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
            act.ShouldThrow<Exception>()
                .And.Message.Should()
                    .Contain("negatives not allowed")
                    .And.Contain("-10");
        }


        [Fact]
        public void Add_With_Multiple_Negative_Numbers_Returns_Exception()
        {
            //Setup

            //Act
            Action act = () => _calulator.Add("-10,-20,10");

            //Assert
            act.ShouldThrow<Exception>()
                .And.Message.Should()
                .Contain("negatives not allowed")
                .And.Contain("-10")
                .And.Contain("-20");
        }
    }
}
