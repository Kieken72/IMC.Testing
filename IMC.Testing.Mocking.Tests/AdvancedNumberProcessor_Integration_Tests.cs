using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Moq;
using Xunit;

namespace IMC.Testing.Mocking.Tests
{
    public class AdvancedNumberProcessor_Integration_Tests
    {
        private readonly AdvancedNumberProcessor _processor;
        private readonly string _fileName = "myfile.txt";

        public AdvancedNumberProcessor_Integration_Tests()
        {
            _processor = new AdvancedNumberProcessor(new ExternalFileShareRepository());

        }

        [Fact]
        public void DoProccesing_Throws_Exception_FileNotFound()
        {
            //Setup
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            //Act
            Action act = () => _processor.DoProcessing();

            //Assert
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void DoProccesing_Works_Normal_WithFile()
        {
            //Setup
            File.WriteAllLines(_fileName, new List<string>(){"1","2"});

            //Act
            _processor.DoProcessing();
            var model = _processor.GetReport();

            //Assert
            Assert.NotNull(model);
            Assert.Equal(2, model.NumberCount);
        }

    }
}
