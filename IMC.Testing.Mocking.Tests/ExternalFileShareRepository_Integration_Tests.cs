using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace IMC.Testing.Mocking.Tests
{
    public class ExternalFileShareRepository_Integration_Tests
    {
        private readonly ExternalFileShareRepository _repo;
        private readonly string _fileName = "myfile.txt";
        private readonly IEnumerable<string> _list;

        public ExternalFileShareRepository_Integration_Tests()
        {
            _repo = new ExternalFileShareRepository();
            _list = new List<string>()
            {
                "1",
                "2",
                "3"
            };
            File.WriteAllLines(_fileName, _list);
        }

        [Fact]
        public void GetAllItems_Returns_List()
        {
            //Setup

            //Act
            var list = _repo.GetAllItems();

            //Assert
            Assert.NotNull(list);
            Assert.Equal(_list.Count(), list.Count());
        }

        [Fact]
        public void GetAllItems_Returns_Exception()
        {
            //Setup
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            //Act
            Action act = () => _repo.GetAllItems();

            //Assert
            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void Save_Saves_File()
        {
            //Setup

            //Act
            _repo.Save(_list);
            var fileExists = File.Exists(_fileName);

            //Assert
            Assert.True(fileExists);
        }
        [Fact]
        public void Save_With_Boem_Throws_Exception()
        {
            //Setup
           var list = _list.ToList();
           list.Add("Boem");

            //Act
            Action act = () => _repo.Save(list);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
