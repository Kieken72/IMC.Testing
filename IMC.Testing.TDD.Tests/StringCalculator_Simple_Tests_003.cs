﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
{
    public class StringCalculator_Simple_Tests_003
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Simple_Tests_003()
        {
            _calulator = new StringCalulator();
        }

        [Fact]
        public void Add_With_Three_Numbers_Returns_Number_Newline()
        {
            //Setup

            //Act
            var number = _calulator.Add("5\\n5,5");

            //Assert
            Assert.Equal(15, number);
        }
    }
}
