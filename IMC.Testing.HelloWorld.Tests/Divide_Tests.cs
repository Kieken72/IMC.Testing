using System;
using Xunit;

namespace IMC.Testing.HelloWorld.Tests
{
    public class Divide_Tests
    {

        private readonly Functions _functions;
        
        private int _a, _b;

        public Divide_Tests()
        {
            _a = 5;
            _b = 5;
            _functions = new Functions();
        }


        [Fact]
        public void Divide_By_Five_Should_Not_Throw_Exception()
        {
            //Setup
            int c;
            _b = 5;

            //Act
            c = _functions.Divide(_a, _b);

            //Assert
            Assert.Equal(c,1);
        }

        [Fact]
        public void Divide_By_Zero_Should_Throw_Exception()
        {
            //Setup
            int c;
            _b = 0;

            //Act
            Action act = () => c = _functions.Divide(_a, _b);

            //Assert
            Assert.Throws<DivideByZeroException>(act);
        }
    }
}
