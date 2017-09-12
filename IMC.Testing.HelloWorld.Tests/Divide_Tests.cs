using System;
using Xunit;

namespace IMC.Testing.HelloWorld.Tests
{
    public class Divide_Tests
    {

        private readonly Functions _functions;

        public Divide_Tests()
        {
            _functions = new Functions();
        }


        [Fact]
        public void Divide_By_Five_Should_Not_Throw_Exception()
        {
            //Setup
            int a, b, c;
            a = 5;
            b = 5;

            //Act
            c = _functions.Divide(a, b);

            //Assert
            Assert.Equal(c,1);
        }

        [Fact]
        public void Divide_By_Zero_Should_Throw_Exception()
        {
            //Setup
            int a, b, c;
            a = 5;
            b = 0;

            //Act
            Action act = () => c = _functions.Divide(a, b);

            //Assert
            Assert.Throws<DivideByZeroException>(act);
        }

        [Theory]
        [InlineData(5,5,1)]
        [InlineData(10, 5, 2)]
        [InlineData(20, 5, 4)]
        [InlineData(10, 10, 1)]
        [InlineData(20, 10, 2)]
        [InlineData(30, 10, 3)]
        [InlineData(4, 4, 1)]
        [InlineData(8, 4, 2)]
        [InlineData(49, 7, 7)]
        [InlineData(56, 7, 8)]
        public void Divide_By_Multiple(int a, int b, int result)
        {
            //Setup
            int c;

            //Act
            c = _functions.Divide(a, b);

            //Assert
            Assert.Equal(c, result);

        }
    }
}
