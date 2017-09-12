using System;
using System.Collections.Generic;
using System.Text;

namespace ICM.Testing.Builder.Tests
{
    public class PersonBuilder
    {
        Person _parent = null;
        string _name = "Filip";
        DateTime _birthDate = DateTime.Now;

        public PersonBuilder withParent(Person parent)
        {
            this._parent = parent;
            return this;
        }

        public PersonBuilder withName(string name)
        {
            this._name = name;
            return this;
        }

        public PersonBuilder withBirthDate(DateTime birthDate)
        {
            this._birthDate = birthDate;
            return this;
        }
        public Person build()
        {
            return new Person(_name, _birthDate, _parent);
        }
    }
}
