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
        public void Divide_By_Zero_Should_Throw_Exception()
        {
            //Setup
            double a, b, c;
            a = 1;
            b = 0;

            //Act
            Action act = () => c =_functions.Divide(a, b);

            //Assert
            Assert.Throws<DivideByZeroException>(act);
        }
    }
}
