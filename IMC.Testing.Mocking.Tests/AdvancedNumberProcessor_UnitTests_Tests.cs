using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace IMC.Testing.Mocking.Tests
{
    public class AdvancedNumberProcessor_UnitTests_Tests
    {
        private readonly AdvancedNumberProcessor __processor;
        private int _saveCalls = 0;
        private int _getCalls = 0;

        public AdvancedNumberProcessor_UnitTests_Tests()
        {
            var mock = new Mock<IExternalFileShareRepository>();

            mock.Setup(m => m.Save(It.IsAny<IEnumerable<string>>()))
                .Callback(() => _saveCalls++);

            mock.Setup(m => m.GetAllItems())
                .Returns(new List<string>()
                {
                    "1",
                    "5",
                    "10"
                })
                .Callback(() => _getCalls++);

            __processor = new AdvancedNumberProcessor(mock.Object);

        }

        [Fact]
        public void DoProccesing_With_MOQ_Calls_GetAllItems()
        {
            //Setup
             //SetUp Fixture ctor

            //Act
            __processor.DoProcessing();

            //Assert
            Assert.True(_getCalls == 1);
        }

        [Fact]
        public void DoProccesing_With_MOQ_Calls_Save()
        {
            //Setup
            //SetUp Fixture ctor

            //Act
            __processor.DoProcessing();

            //Assert
            Assert.True(_saveCalls == 1);
        }

        [Fact]
        public void GetReport_With_MOQ_Returns_Model()
        {
            //Setup

            //Act
            var model = __processor.GetReport();

            //Assert
            Assert.Equal(3, model.NumberCount);
            Assert.Equal((1 + 5 + 10) / 3.0, model.Average);
        }

        [Fact]
        public void DoProccessing_With_Twelve_Throws_ArgumentException()
        {
            //Setup
            var mock = new Mock<IExternalFileShareRepository>();

            mock.Setup(m => m.GetAllItems())
                .Returns(new List<string>()
                {
                    "1",
                    "5",
                    "12"
                })
                .Callback(() => _getCalls++);

            var processor = new AdvancedNumberProcessor(mock.Object);

            //Act
            Action act = () => processor.DoProcessing();

            //Asert
            Assert.Throws<ArgumentException>(act);

        }
    }
}
