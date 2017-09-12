using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
{
    public class StringCalculator_Theory_Tests
    {
        private readonly StringCalulator _calculator;

        public StringCalculator_Theory_Tests()
        {
            _calculator = new StringCalulator();
        }
        [Theory]
        [InlineData("8,8,8,8",32)]
        [InlineData("5,5,5,5", 20)]
        [InlineData("10\\n10\\n,10,10",40)]
        [InlineData(@"\\*\n10*10*,10\n10", 40)]
        [InlineData(@"\\**\n10**10**,10\n10", 40)]
        [InlineData(@"\\[*][%]\n10*10%,10\n10", 40)]
        [InlineData(@"\\[**][%%]\n10**10%%,10\n10", 40)]
        [InlineData(@"\\[**][%%]\n10**10%%,10\n1001", 30)]
        public void Add_Theory(string numberString, int total)
        {
            //Setup

            //Act
            var sum = _calculator.Add(numberString);

            //Assert
            Assert.Equal(total, sum);

        }
    }
}
