using System;
using System.Linq;
using Xunit;

namespace ICM.Testing.Builder.Tests
{
    public class PersonProcessorTests_Without_Builder
    {
        private readonly PersonProcessor _processor;
        public PersonProcessorTests_Without_Builder()
        {
            _processor = new PersonProcessor();
        }

        [Fact]
        public void Person_Has_LongName_Tag()
        {
            //Setup
            var person = new Person("Bart Peeters", DateTime.Now);
            
            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(1, person.Tags.Count);
            Assert.Equal("LongName", person.Tags.First());
        }

        [Fact]
        public void Person_Has_Volwassen_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now.AddYears(-19));

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(1, person.Tags.Count);
            Assert.Equal("Volwassen",person.Tags.First());
        }

        [Fact]
        public void Person_Has_Pensioen_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now.AddYears(-66));

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Pensioen"));
        }
        [Fact]
        public void Person_Has_Parent_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now, new Person("Filip", DateTime.Now));
            

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(1, person.Tags.Count);
            Assert.True(person.Tags.Contains("Ouder gekend"));
        }

        [Fact]
        public void Person_Has_Parent_And_Only_Child_Tag()
        {
            //Setup
            var parent = new Person("Filip", DateTime.Now);
            parent.RegisterChild("Bart", DateTime.Now);
            var person = new Person("Bart", DateTime.Now, parent);


            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Ouder gekend"));
            Assert.True(person.Tags.Contains("Enig kind"));
        }

        [Fact]
        public void Person_Has_Children_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now);
            person.RegisterChild("Jef", DateTime.Now);

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Heeft kinderen"));
        }
        [Fact]
        public void Person_Has_Children_Has_One_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now);
            person.RegisterChild("Jef", DateTime.Now);

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Heeft kinderen"));
            Assert.True(person.Tags.Contains("1 kind"));
        }

        [Fact]
        public void Person_Has_Children_Has_Two_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now);
            person.RegisterChild("Jef", DateTime.Now);
            person.RegisterChild("Filip", DateTime.Now);

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Heeft kinderen"));
            Assert.True(person.Tags.Contains("2 kinderen"));
        }

        [Fact]
        public void Person_Has_Children_Has_Many_Tag()
        {
            //Setup
            var person = new Person("Bart", DateTime.Now);
            person.RegisterChild("Jef", DateTime.Now);
            person.RegisterChild("Filip", DateTime.Now);
            person.RegisterChild("Rob", DateTime.Now);

            //Act
            _processor.ProcessEntity(person);

            //Assert
            Assert.Equal(2, person.Tags.Count);
            Assert.True(person.Tags.Contains("Heeft kinderen"));
            Assert.True(person.Tags.Contains("Veel kinderen"));
        }
    }
}
