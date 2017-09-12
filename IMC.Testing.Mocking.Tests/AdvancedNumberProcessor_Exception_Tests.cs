using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;

namespace IMC.Testing.Mocking.Tests
{
    public class AdvancedNumberProcessor_Exception_Tests
    {
        private readonly Mock<IExternalFileShareRepository> _mock;

        public AdvancedNumberProcessor_Exception_Tests()
        {
            _mock = new Mock<IExternalFileShareRepository>();

            _mock.Setup(m => m.Save(It.IsAny<IEnumerable<string>>()));
        }

        [Fact]
        public void DoProccesing_With_Number_12_Gives_Exception()
        {
            //Setup
            _mock.Setup(m => m.GetAllItems())
                .Returns(new List<string>()
                {
                    "1",
                    "5",
                    "12"
                });
            var processor = new AdvancedNumberProcessor(_mock.Object);

            //Act
            Action act = () => processor.DoProcessing();

            //Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
