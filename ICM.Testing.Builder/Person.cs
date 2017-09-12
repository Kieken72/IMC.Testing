using System;
using System.Collections.Generic;

namespace ICM.Testing.Builder
{
    public class Person
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public Person Parent { get; }
        public List<Person> Children { get; } = new List<Person>();

        public List<string> Tags { get; set; } = new List<string>();

        public Person(string name, DateTime birthDate, Person parent = null)
        {
            Name = name;
            BirthDate = birthDate;
            Parent = parent;
        }

        public Person RegisterChild(string name, DateTime birthdate)
        {
            var child = new Person(name, birthdate, this);
            Children.Add(child);
            return child;
        }

        public void Tag(string tag)
        {
            Tags.Add(tag);
        }
    }
}