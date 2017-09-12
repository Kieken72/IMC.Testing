using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;

namespace IMC.Testing.Mocking.Tests
{
    public class AdvancedNumberProcessor_Tests
    {
        private readonly IExternalFileShareRepository _repo;
        private int _saveCalls = 0;
        private int _getCalls = 0;

        public AdvancedNumberProcessor_Tests()
        {
            var mock = new Mock<IExternalFileShareRepository>();

            mock.Setup(m => m.Save(It.IsAny<IEnumerable<string>>()))
                .Callback(()=> _saveCalls++);

            mock.Setup(m => m.GetAllItems())
                .Returns(new List<string>()
                {
                    "1",
                    "5",
                    "10"
                })
                .Callback(() => _getCalls++);

            _repo = mock.Object;

        }

        [Fact]
        public void DoProcessing_Without_MOQ_Gives_Exception()
        {

            //Setup
           var processor = new AdvancedNumberProcessor(new ExternalFileShareRepository());

            //Act
            Action act = () => processor.DoProcessing();

            //Assert
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void DoProccesing_With_MOQ_Calls_Methods()
        {
            //Setup
            var processor = new AdvancedNumberProcessor(_repo);

            //Act
            processor.DoProcessing();

            //Assert
            Assert.True(_getCalls == 1);
            Assert.True(_saveCalls == 1);
        }

        [Fact]
        public void GetReport_Without_MOQ_Gives_Exception()
        {
            var processor = new AdvancedNumberProcessor(new ExternalFileShareRepository());

            OverviewModel model;
            //Act
            Action act = () => model= processor.GetReport();

            //Assert
            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void GetReport_With_MOQ_Calls_Get()
        {
            var processor = new AdvancedNumberProcessor(_repo);

            //Act
            var model = processor.GetReport();

            //Assert
            Assert.True(_getCalls == 1);
        }
        [Fact]
        public void GetReport_With_MOQ_Returns_Model()
        {
            var processor = new AdvancedNumberProcessor(_repo);

            //Act
            var model = processor.GetReport();

            //Assert
            Assert.Equal(model.NumberCount, 3);
            Assert.Equal(model.Average, (1 + 5 + 10) / 3.0);
        }
    }
}
