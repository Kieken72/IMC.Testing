using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests.Auto_Fixture
{
    public class CalculatorTests
    {

        private readonly Functions _functions;
        
        public CalculatorTests()
        {
            _functions = new Functions();
        }


        [Theory, AutoData]
        public void Should_Multiply_AutoData(int a, int b)
        {
            //Setup
            int c;

            //Act
            c = _functions.Multiply(a, b);

            //Assert
            Assert.Equal(a*b, c);
        }

        [Fact]
        public void Should_Multiply()
        {
            //Setup
            Fixture fixture = new Fixture();
            var a = fixture.Create<int>();
            var b = fixture.Create<int>();

            //Act
            var result = _functions.Multiply(a, b);

            //Assert
            Assert.Equal(a*b, result);
            result.Should().Be(a * b);
        }

    }
}
