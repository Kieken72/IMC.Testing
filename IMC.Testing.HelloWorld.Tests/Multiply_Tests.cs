using System;
using Xunit;

namespace IMC.Testing.HelloWorld.Tests
{
    public class Multiply_Tests
    {

        private readonly Functions _functions;

        private int _a, _b;

        public Multiply_Tests()
        {
            _functions = new Functions();
        }


        [Fact]
        public void Multiply_By_Five_Should_Give_TwentyFive()
        {
            //Setup
            _a = 5;
            _b = 5;
            int c;

            //Act
            c = _functions.Multiply(_a, _b);

            //Assert
            Assert.Equal(25, c);
        }

    }
}
