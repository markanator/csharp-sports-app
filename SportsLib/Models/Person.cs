using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib.Models
{
    public abstract class Person : IPerson
    {
        public string Name { get; set; }

        public Person(string _name)
        {
            this.Name = _name;
        }
    }
}